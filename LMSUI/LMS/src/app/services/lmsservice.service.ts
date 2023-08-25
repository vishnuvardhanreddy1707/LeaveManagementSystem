import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/Employee.model';
import { Observable } from 'rxjs';
import { Leave } from '../models/Leave.model';


@Injectable({
  providedIn: 'root'
})
export class LMSServiceService {
  readonly APIUrl ="https://localhost:7181/api/";

  constructor(private http:HttpClient) { }

  getAllEmployees():Observable<Employee[]>{
    return this.http.get<Employee[]>(this.APIUrl + 'Employee/GetAllEmployees')

  }
  addEmployee(val:any){
    return this.http.post<Employee>(this.APIUrl+'Employee/AddEmployee',val);

  }
  deleteEmployee(id:number){
    return this.http.delete<Employee>(this.APIUrl+'Employee/DeleteEmployee?EmployeeId='+id)
   }
   updateEmployee(val:any){
    return this.http.put<any>(this.APIUrl+'Employee/UpdateEmployee',val)
   }
   searchEmployee(Eid:number){
    return this.http.get<Employee>(this.APIUrl+'Employee/GetEmployee?EmployeeId='+Eid)
   }
   Login(formData:any){
    console.log(formData);
    return this.http.post<Employee>(this.APIUrl+'Employee/login',formData)
   }
   AddLeave(val:any){
    return this.http.post<Leave>(this.APIUrl+'Leave/AddLeave',val);
 }

 
}
