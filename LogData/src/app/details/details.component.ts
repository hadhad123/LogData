import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
logID: number;
LogDetails:any = {
  LogMessage:'',
  CreationDateTime:null,
  LogType:{
    LogName:''
  }
};

  constructor(private route: ActivatedRoute,private httpClient: HttpClient) {
    this.route.params.subscribe(
      res => 
       this.logID = res.id
    )
   }

  ngOnInit() {
    this.getLogDetails();
  }

  getLogDetails()
  {
    this.httpClient.get(`http://localhost/LogDataWebAPI/api/Logs/`+this.logID)
      .subscribe(
        (data) => {
          this.LogDetails = data;
        }
      )
  }

}
