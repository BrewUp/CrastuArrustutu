namespace CrastuArrustutu.Shared.Dtos
{
    public class LastEventPosition : DtoBase
	{
		public ulong CommitPosition { get; set; }
		public ulong PreparePosition { get; set; }
	}
}
