import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
import { Product } from "./product";
import { Order, OrderItem } from "./order";
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
    public products: Product[] = [];
    public order: Order = new Order();
    public loadProducts(): Observable<Product[]> {
       return this.http.get("/api/products")
            .pipe(
                map((result: Response) => this.products = result.json())
            );
    }
    public addToOrder(newProduct: Product) {
        let item: OrderItem = this.order.items.find(i => i.productId == newProduct.id);
        if (item)
        {
            item.quantity++;
        }
        else {
            item = new OrderItem();
            item.productId = newProduct.id;
            item.productArtist = newProduct.artist;
            item.productArtId = newProduct.artId;
            item.productCategory = newProduct.category;
            item.productSize = newProduct.size;
            item.productTitle = newProduct.title;
            item.unitPrice = newProduct.price;
            item.quantity = 1;

            this.order.items.push(item);
        }
    }
}