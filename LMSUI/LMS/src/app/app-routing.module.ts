import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './components/employee/employee.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { LeaveComponent } from './components/leave/leave.component';

const routes: Routes = [
  {
    path:'Employee',
    component:EmployeeComponent
  },
  {
    path:'login',
    component:LoginComponent
  },
  {
    path:'login/home',
    component:HomeComponent
  },
  {
    path:'login/Leave',
    component:LeaveComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
