using DataPresentation.Common;
using DataPresentation.Data;
using VKApiService;
using VKApiService.Base;

namespace DataPresentation
{
    public class SendPostProcessPresenter : BasePresenter<ISendPostProcessView, SendPostData>
    {
        private readonly IVkApiService _vkApiService;
        private SendPostData? _sendPostData;
        private readonly CancellationTokenSource _sendPostProcessController;


        public SendPostProcessPresenter(IApplicationController applicationController, ISendPostProcessView view, IVkApiService vkApiService) : base(applicationController, view)
        {
            _vkApiService = vkApiService;
            View.OnViewClosed += DisposeProcess;
            _sendPostProcessController = new CancellationTokenSource();
        }

        public override void Run(SendPostData sendPostData)
        {
            _sendPostData = sendPostData;
            View.SetupProgressBar(_sendPostData.GroupUrls.Count);
            Task task = SendPostsInGroups(_sendPostProcessController.Token);
            View.Show();
        }


        private async Task SendPostsInGroups(CancellationToken cancellationToken)
        {
            if (_sendPostData == null)
                throw new ArgumentNullException(nameof(_sendPostData), "Send post data is not set!");

            foreach (string groupUrl in _sendPostData.GroupUrls)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (!groupUrl.StartsWith("https://vk.com/"))
                {
                    View.SendPostProcessErrorLog(groupUrl, "Wrong Url!");
                    View.IncrementProgressBar();
                    continue;
                }

                cancellationToken.ThrowIfCancellationRequested();
                string screenName = groupUrl.Replace("https://vk.com/", "");
                VkApiResponse objectInfo = await _vkApiService.GetObjectInfo(screenName);

                long groupId;
                if (objectInfo.ResponseData != null)
                {
                    groupId = -(long)objectInfo.ResponseData["object_id"];
                }
                else
                {
                    View.SendPostProcessErrorLog(groupUrl, "Failed get group id!");
                    View.IncrementProgressBar();
                    continue;
                }

                cancellationToken.ThrowIfCancellationRequested();
                VkApiResponse sendPostResult = await _vkApiService.SendPostToGroup(groupId, _sendPostData.PostContent);
                if (sendPostResult.ResponseData != null)
                {
                    View.SendPostProcessSuccessLog(groupUrl);
                }
                else if (sendPostResult.ErrorData != null)
                {
                    string? errorMessage = sendPostResult.ErrorData["error_msg"].ToString();
                    if (errorMessage == null)
                        errorMessage = "Unknown error!";

                    View.SendPostProcessErrorLog(groupUrl, errorMessage);
                }

                cancellationToken.ThrowIfCancellationRequested();
                View.IncrementProgressBar();
                await Task.Delay(350, cancellationToken);
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        private void DisposeProcess()
        {
            _sendPostProcessController.Cancel();
        }
    }
}
