import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './components/employee/employee.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { LeaveComponent } from './components/leave/leave.component';
import { AuthGuard } from './Auth/auth.guard';

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
    path:'home',
    component:HomeComponent,canActivate:[AuthGuard]
  },
  {
    path:'login/Leave',
    component:LeaveComponent,canActivate:[AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
