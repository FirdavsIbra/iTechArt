namespace iTechArt.Domain.ModelInterfaces
{
    public interface IDashboardInfo
    {
        /// <summary>
        /// Gets count of pupils
        /// </summary>
        
        public int PupilCount { get; }

        /// <summary>
        /// Gets count of students
        /// </summary>
        public int StudentCount { get; }

        /// <summary>
        /// Gets count of groceries
        /// </summary>
        public int GroceryCount { get; }

        /// <summary>
        /// Gets count of polices
        /// </summary>
        public int PoliceCount { get; }

        /// <summary>
        /// Gets count of doctors
        /// </summary>
        public int DoctorCount { get; }

        /// <summary>
        /// Gets count of airports
        /// </summary>
        public int AirportCount { get; }
    }
}
