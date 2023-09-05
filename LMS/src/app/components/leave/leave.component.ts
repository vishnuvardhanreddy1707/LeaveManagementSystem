import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ConnectableObservable } from 'rxjs';
import { Leave } from 'src/app/models/Leave.model';
import { LMSServiceService } from 'src/app/services/lmsservice.service';

@Component({
  selector: 'app-leave',
  templateUrl: './leave.component.html',
  styleUrls: ['./leave.component.css']
})
export class LeaveComponent implements OnInit {
  userDetails!:any;
  formValue !:FormGroup;
  leaveModelObj:Leave= new Leave();
  invalidLeave!: boolean;
  showAdd!:boolean;
  showUpdate!:boolean;
  ApplyLeaveForm=new FormGroup({
    leaveId:new FormControl,
    employeeId:new FormControl,
    employeeName:new FormControl,
    startDate:new FormControl,
    endDate:new FormControl,
    leaveName:new FormControl,
    leaveDescription:new FormControl,
    // status:new FormControl('',Validators.required),
    // statusDescription:new FormControl('',Validators.required)
  });
  leave:any=null;

  constructor(private formbuilder:FormBuilder,private lmsservice:LMSServiceService,private router:Router) { }

  ngOnInit(): void {
    this.lmsservice.getUserProfile().subscribe(
      res=>{
        this.userDetails=res;
      },
      err=>{
        console.log(err);
      },
    );
    this.formValue=this.formbuilder.group({
      leaveId:[''],
      employeeId:[''],
      employeeName:[''],
      startDate:[''],
      endDate:[''],
      leaveName:[''],
      leaveDescription:[''],
      status:[''],
      statusDescription:['']
     

    })
  }
  clickAddLeave(){
    this.formValue.reset();
    this.showAdd=true;
    this.showUpdate=false;
  }
  AddLeave(){
    this.leaveModelObj.employeeId=this.formValue.value.employeeId;
    this.leaveModelObj.employeeName=this.formValue.value.employeeName;
    this.leaveModelObj.startDate=this.formValue.value.startDate;
    this.leaveModelObj.endDate=this.formValue.value.endDate;
    this.leaveModelObj.leaveName=this.formValue.value.leaveName;
    this.leaveModelObj.status=this.formValue.value.status;
    this.leaveModelObj.leaveDescription=this.formValue.value.leaveDescription;
    this.leaveModelObj.statusDescription=this.formValue.value.statusDescription;
    console.log(this.leaveModelObj); 
    this.lmsservice.AddLeave(this.leaveModelObj)  
    .subscribe (res=>{
      console.log(res);
    alert("employee Added sucessfully")
    
    })
    
  }
  get f(){
    return this.ApplyLeaveForm.controls;
  }
  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

}
