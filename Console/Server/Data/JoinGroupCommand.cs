namespace Diplomeocy.Console.Server.Data;

public class JoinGroupCommand : Command {
	public override required string Kind { get; init; } = "JoinGroup";
	public required string Group { get; init; }
}