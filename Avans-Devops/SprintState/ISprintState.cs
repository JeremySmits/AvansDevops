namespace Avans_Devops
{
    public interface ISprintState
    {
        public int SprintId { get; set; }
        public int BacklogId { get; set; }

        public void UpdateSprinteDetails() { }
        public void BacklogItemsAdd() { }
        public void RemoveBacklogItem(BacklogItem BacklogItem) { }
        public void ReleaseSprint() { }
    }
}