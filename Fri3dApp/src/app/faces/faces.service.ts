import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
 
const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
 
@Injectable()
export class FaceService {
 
    constructor(private http:HttpClient) {}
    
    // Uses http.get() to load data from a single API endpoint
    requestFace(face) {
        let ip = window.location.hostname;
        console.log(ip);
        let body = JSON.stringify(face);
        return  this.http.post('http://'+ip+':5000/api/faces/add', body, httpOptions);
    }
}