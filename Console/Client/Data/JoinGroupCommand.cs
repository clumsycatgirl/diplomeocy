namespace Diplomeocy.Console.Client.Data;

public class JoinGroupCommand : Command {
	public override string Kind { get; init; } = "JoinGroup";
	public required string Group { get; init; }
}