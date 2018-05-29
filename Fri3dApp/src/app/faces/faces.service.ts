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
        let body = JSON.stringify(face);
        console.log(body);
        return  this.http.post('http://localhost:53550/api/faces/add', body, httpOptions);
    }
}