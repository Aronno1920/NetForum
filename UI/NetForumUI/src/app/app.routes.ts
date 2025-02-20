import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { CategoryListComponent } from './features/category/category-list/category-list.component';

export const routes: Routes = [
    {
        path:'admin/categories',
        component:CategoryListComponent
    }
];

@NgModule({
    imports: [
        HttpClientModule,
        RouterModule.forRoot(routes)
    ],
    exports: [RouterModule],
})

export class AppRoutingModule {}
