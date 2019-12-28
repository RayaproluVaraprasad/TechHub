import { Component, OnInit } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrls: ['./employeelist.component.css']
})
export class EmployeelistComponent implements OnInit {



  constructor(private httpService: HttpClient) { }
  employees: string[];

  private getemployees = 'http://localhost:55303/Employee/GetEmployees';

  ngOnInit() {
    this.getEmployeedata();
  }

  getEmployeedata() {
    this.httpService.get(this.getemployees).subscribe(
      data => {
        this.employees = data as string[]
      }
    )
  }

}
