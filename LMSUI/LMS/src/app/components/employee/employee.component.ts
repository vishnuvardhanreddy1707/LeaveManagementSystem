import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/Employee.model';
import { LMSServiceService } from 'src/app/services/lmsservice.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  formValue !:FormGroup;
  employeeModelObj:Employee= new Employee();
  employeeData!:any;
  showAdd!:boolean;
  showUpdate!:boolean;

  constructor(private formbuilder:FormBuilder,private router:Router,private service:LMSServiceService) { }

  ngOnInit(): void {
    this.formValue=this.formbuilder.group({
      employeeId:[''],
      employeeName:[''],
      employeeDOB:[''],
      email:[''],
      password:['']

    })
    this.getAllEmployees();
  }
  getAllEmployees(){
    this.service.getAllEmployees()
     .subscribe(res=>{
      this.employeeData=res;
    })

  }
  clickAddEmployee(){
    this.formValue.reset();
    this.showAdd=true;
    this.showUpdate=false;
  }
  addEmployee(){
    this.employeeModelObj.employeeName=this.formValue.value.employeeName;
    this.employeeModelObj.employeeDOB=this.formValue.value.employeeDOB;
    this.employeeModelObj.email=this.formValue.value.email;
    this.employeeModelObj.password=this.formValue.value.password;
    console.log(this.employeeModelObj);
    this.service.addEmployee(this.employeeModelObj)
    .subscribe(res=>{
      console.log(res);
    alert("employee Added sucessfully")
  let ref=document.getElementById('cancel')
   ref?.click();
  this.formValue.reset();
this.getAllEmployees();},
    err=>{
      alert("something went wrong")
    })
  }
  deleteemployee(id:number){
    if(confirm('Are you sure?')){
      this.service.deleteEmployee(id).subscribe(data=>{
        console.log(data);
        
      });
      
    }
  
  }

  onEdit(row:any){
    this.showAdd=false;
    this.showUpdate=true;
    this.formValue.controls['employeeId'].setValue(row.employeeId);
    this.formValue.controls['employeeName'].setValue(row.employeeName);
    this.formValue.controls['employeeDOB'].setValue(row.employeeDOB);
    this.formValue.controls['email'].setValue(row.email);
    this.formValue.controls['password'].setValue(row.password);

  }
  updateEmployee(){
    this.employeeModelObj.employeeId=this.formValue.value.employeeId;
    this.employeeModelObj.employeeName=this.formValue.value.employeeName;
    this.employeeModelObj.employeeDOB=this.formValue.value.employeeDOB;
    this.employeeModelObj.email=this.formValue.value.email;
    this.employeeModelObj.password=this.formValue.value.password;
    this.service.updateEmployee(this.employeeModelObj)
    .subscribe(res=>{
      alert("updated sucessfully");
      let ref=document.getElementById('cancel')
      ref?.click();
      this.formValue.reset();
      this.getAllEmployees();
    })

  }
}
