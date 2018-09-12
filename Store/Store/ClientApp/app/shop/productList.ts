﻿import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";

@Component({
    selector: "product-list",
    templateUrl: "productList.component.html",
    styleUrls: []
})
export class ProductList implements OnInit {
    public products;

     constructor(private data: DataService) {
         this.products = data.products;
     }
     ngOnInit(): void {
         this.data.loadProducts()
             .subscribe(result => this.products = result);
    }
}