namespace Vein360.Application.Common.Exceptions
{
    [Serializable]
    internal class NotFoundException : Exception
    {
        private string v;
        private int donationContainerId;



        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string v, int donationContainerId) : this($"{v} with id {donationContainerId} was not found.")
        {
            this.v = v;
            this.donationContainerId = donationContainerId;
        }
    }
}