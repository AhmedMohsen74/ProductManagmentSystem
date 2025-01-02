export interface Product{
    id:number,
    name: string,
    description: string,
    price: number,
    createdDate: Date | null;
    categoryId: number,
    categoryName: string
}