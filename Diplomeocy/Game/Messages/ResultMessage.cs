using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Messages;
internal class ResultMessage {
	public enum EResult {
		Success, 
		Fail
	};
	public EResult Result { get; set; } = EResult.Success;
	public string Message { get; set; } = "";
}
