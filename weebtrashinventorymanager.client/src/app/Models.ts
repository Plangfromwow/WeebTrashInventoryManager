export interface ScannedInventoryItem {
    barcodeScan: string;
    category: string;
    subCategory: string;
    title: string;
    description: string;
    quantity: string;
    whatNotType: string;
    price: string;
    shippingProfile: string;
    gradable: string;
    offerable: string;
    hazmat: string;
    imageURL1: string;
    imageURL2: string;
    imageURL3: string;
    imageURL4: string;
    imageURL5: string;
    imageURL6: string;
    imageURL7: string;
    imageURL8: string;
}
export interface options {
    name: string,
    barcodeScan?: string | null
}

export interface WhatNotItem {
    category: string;
    subCategory: string;
    title: string;
    description: string;
    quantity: string;
    whatNotType: string;
    price: string;
    shippingProfile: string;
    gradable: string;
    offerable: string;
    hazmat: string;
    imageURL1: string;
    imageURL2: string;
    imageURL3: string;
    imageURL4: string;
    imageURL5: string;
    imageURL6: string;
    imageURL7: string;
    imageURL8: string;
}


export interface JsonResponseObject {
    message: string;
    StatusCode: string;
    ResponseObject: any;
    ResponseObjects: any[];
}