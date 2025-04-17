namespace API_Pointage.Helpers
{
    public static class ErrorCodes
    {
        //General error codes
        public const string EmployeeNotFound = "EMPLOYEE_NOT_FOUND";
        public const string CheckInExists = "CHECKIN_EXISTS";
        public const string CheckInNotFound = "CHECKIN_NOT_FOUND";
        public const string InvalidCheckOutTime = "INVALID_CHECKOUT_TIME";
        public const string NoAttendance = "NO_ATTENDANCE";
        public const string InvalidDate = "INVALID_DATE";

        //Department related error codes
        public const string IdMismatch = "ID_MISMATCH";
        public const string DepartmentNotFound = "DEPARTMENT_NOT_FOUND";

        //Attendance related error codes

        //  ScanPoint related error codes

        //  Employee related error codes
        public const string EmailAlreadyExists = "EMAIL_ALREADY_EXISTS";
        public const string MissingFields = "MISSING_FIELDS";


        //  NFC related error codes

        //  QR related error codes

        //  Other error codes

        //  Add more error codes as needed


    }
}
