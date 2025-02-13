namespace Web.Messages;
internal class ResultMessage {
	public enum EResult {
		Success,
		Fail
	};
	public EResult Result { get; set; } = EResult.Success;
	public string Message { get; set; } = "";
}
