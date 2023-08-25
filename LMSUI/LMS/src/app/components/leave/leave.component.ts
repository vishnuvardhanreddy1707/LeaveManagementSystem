import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LMSServiceService } from 'src/app/services/lmsservice.service';

@Component({
  selector: 'app-leave',
  templateUrl: './leave.component.html',
  styleUrls: ['./leave.component.css']
})
export class LeaveComponent implements OnInit {
  invalidLeave!: boolean;
  ApplyLeaveForm=new FormGroup({
    leaveId:new FormControl('',Validators.required),
    employeeId:new FormControl('',Validators.required),
    employeeName:new FormControl('',Validators.required),
    startDate:new FormControl('',Validators.required),
    endDate:new FormControl('',Validators.required),
    leaveName:new FormControl('',Validators.required),
    leaveDescription:new FormControl('',Validators.required),
    // status:new FormControl('',Validators.required),
    // statusDescription:new FormControl('',Validators.required)
  });
  leave:any=null;

  constructor(private lmsservice:LMSServiceService,private router:Router) { }

  ngOnInit(): void {
  }
  AddLeave(){
    console.log(this.ApplyLeaveForm.value);
    this.lmsservice.AddLeave(this.ApplyLeaveForm.value)
                    .subscribe(
                      data=>{
                        this.leave=data;
                      this.invalidLeave=false;
                    alert("Leave Applied Sucessfully")
                  },
                  err=>{
                    alert("something went wrong"+err);
                  }
                    );
  }
  get f(){
    return this.ApplyLeaveForm.controls;
  }

}
