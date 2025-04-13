import { v4 as uuidv4 } from 'uuid';
export class Employee {
  EmployeeId: string;
  FirstName: string;
  LastName: string;
  Position: string;
  PositionId: string;
  DateHired: string;
  Email: string;
  Department?: string; // Optionnel comme dans le modèle C#
  DepartmentId: string;
  CreatedAt: string;

  constructor(
    EmployeeId: string = uuidv4(),
    FirstName: string,
    LastName: string,
    Position: string,
    PositionId: string,
    DateHired: string,
    Email: string,
    DepartmentId: string,
    Department?: string,
    CreatedAt: string = new Date().toISOString()
  ) {
    this.EmployeeId = EmployeeId;
    this.FirstName = FirstName;
    this.LastName = LastName;
    this.Position = Position;
    this.PositionId = PositionId;
    this.DateHired = DateHired;
    this.Email = Email;
    this.DepartmentId = DepartmentId;
    this.Department = Department;
    this.CreatedAt = CreatedAt;
  }
}
