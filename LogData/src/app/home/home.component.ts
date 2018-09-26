import { Component, OnInit } from '@angular/core';
import { trigger, style, transition, animate, keyframes, query, stagger } from '@angular/animations';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';
import { RequestOptions } from '@angular/http';
import { Router} from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [
    trigger('goalsAnimation', [
      transition('* => *', [
        query(':enter', style({ opacity: 0 }), { optional: true }),
        query(':enter', stagger('300ms', [
          animate('.6s ease-in', keyframes([
            style({ opacity: 0, transform: 'translateY(-75%)', offset: 0 }),
            style({ opacity: .5, transform: 'translateY(35px)', offset: .3 }),
            style({ opacity: 1, transform: 'translateY(0)', offset: 1 }),
          ]))
        ]), { optional: true }),

        query(':leave', stagger('300ms', [
          animate('.6s ease-in', keyframes([
            style({ opacity: 1, transform: 'translateY(0)', offset: 0 }),
            style({ opacity: .5, transform: 'translateY(35px)', offset: .3 }),
            style({ opacity: 0, transform: 'translateY(-75%)', offset: 1 }),
          ]))
        ]), { optional: true })


      ])
    ])
  ]
})
export class HomeComponent implements OnInit {

  //initializing page number 'p' to one 
  p: number = 0;
  size: number = 2;
  totalRecords: number = 0;
  Logs:any = [];
  LogTypes : any =[];

  filterObject = {
    PageNumber: this.p,
    PageSize: this.size,
    SearchObject: {
      LogTypeID:null
    }
  };

  constructor(private httpClient: HttpClient, private pagination: NgxPaginationModule,private router: Router) { }

  ngOnInit() {
    this.getPagedData();
    this.getLogTypes();
  }

  getLogTypes() {
    this.httpClient.get(`http://localhost/LogDataWebAPI/api/LogTypes`)
      .subscribe(
        (data) => {
          this.LogTypes = data;
        }
      )
  }

  getPagedData() {
    var filterObjectData = JSON.stringify(this.filterObject);

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    this.httpClient.post(`http://localhost/LogDataWebAPI/api/Logs/PagedLogData/`,
      filterObjectData, httpOptions)
      .subscribe(
        (data: any) => {
          //returns list and total number of records 
          this.Logs = data.Results;
          this.totalRecords = data.TotalNumOfRecords;
        },
        error => {
          console.log("Error loading data!", error);
        }
      )
  }

  pageChanged(pageNumber) {
    this.p = pageNumber;
    this.filterObject.PageNumber = this.p - 1;
    this.getPagedData();
  }

  typechanged(typeID){
    this.filterObject.SearchObject.LogTypeID = typeID;
  }

  reset(){
    this.filterObject = {
      PageNumber: this.p,
      PageSize: this.size,
      SearchObject: {
        LogTypeID:null
      }
    };

    this.getPagedData();
  }

  getDetails(ID)
  {
    console.log(ID)
    this.router.navigate(['details/'+ID]);
  }

}
