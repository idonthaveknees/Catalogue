import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductService } from '../product/product.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css'],
})
export class ProductFormComponent implements OnInit {
  productForm!: FormGroup;

  constructor(private fb: FormBuilder, private productService: ProductService) {}

  ngOnInit(): void {

    this.productForm = this.fb.group({
      code: ['', [Validators.required, Validators.pattern(/^[A-Za-z]{2}\d{3}$/)]],
      name: ['', [Validators.required]],
      price: ['', [Validators.required, Validators.min(0)]],
    });
  }

  onSubmit() {
    if (this.productForm.valid) {
      const newProduct = this.productForm.value;
      this.productService.addProduct(newProduct).subscribe((createdProduct) => {
        console.log('Product added successfully:', createdProduct);
        this.productForm.reset();
      });
    } else {
      console.error('Form is not valid.');
    }
  }
}
