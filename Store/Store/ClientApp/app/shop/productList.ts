﻿import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";
import { Product } from "../shared/product";
@Component({
    selector: "product-list",
    templateUrl: "productList.component.html",
    styleUrls: ["productList.component.css"]
})
export class ProductList implements OnInit {
    public products: Product[];

     constructor(private data: DataService) {
         this.products = data.products;
     }
     ngOnInit(): void {
         this.data.loadProducts()
             .subscribe(result => this.products = result);
    }
    public addProduct(p: Product): void {
        this.data.addToOrder(p);
    }
}