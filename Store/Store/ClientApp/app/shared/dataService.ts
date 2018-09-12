import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { map } from 'rxjs/operators';
@Injectable()
export class DataService {
    constructor(private http: Http) {

    }
    /*public products = [
        {
            title: "First",
            price: 19.99

        },
        {
            title: "First",
            price: 19.99
        }];*/
    public products = [];
    public loadProducts() {
       return this.http.get("/api/products")
            .pipe(
                map((result: Response) => this.products = result.json())
            );
    }
}