import React from "react";
import { useSelector } from "react-redux";
import { selectRegisterData } from "../features/register/registerSlice";

export default function BreedInfo({selectedBreed}) {
    const {breeds} = useSelector(selectRegisterData);
    const [breed] = breeds.filter(breed=>breed.Name === selectedBreed);

    const imageStyle ={
        height: '200px',
        width: '200px'
    }

    return (
        <div className="container my-1">
            <div className="d-flex justify-content-between">
                <div className="mx-1">
                    <div className="border-bottom">LifeSpan : {breed.Life_Span?breed.Life_Span:'No data'}</div>
                    <div className="border-bottom">Height : {breed.Height && breed.Height != 'NaN'?breed.Height + ' cm':"No data"}</div>
                    <div className="border-bottom">Weight : {breed.Weight && breed.Weight != 'NaN'?breed.Weight + ' kg':"No data"}</div>
                    <div className="border-bottom">Temperament : {breed.Temperament?breed.Temperament:"No data"}</div>
                    <div className="border-bottom">Origin : {breed.Origin?breed.Origin:"No data"}</div>
                </div>
                <img src={`https://cdn2.thedogapi.com/images/${breed.Reference_image_id}.jpg`} style={imageStyle} />
            </div>
        </div>
    )
}