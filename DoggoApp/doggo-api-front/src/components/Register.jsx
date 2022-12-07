import React from "react";
import { useRef } from "react";
import {useNavigate} from 'react-router-dom';
import { useSelector, useDispatch } from "react-redux";
import DropSelect from "./DropSelect";
import { useEffect } from "react";
import {getRegisterData, selectRegisterData} from '../features/register/registerSlice';
import Autocomplete from "./Autocomplete";
import axios from 'axios';
import { setRegisterIndexData } from "../features/register/registerActions";

export default function Register() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const data = useSelector(selectRegisterData);
    const name = useRef();
    const age = useRef();
    const height = useRef();
    const length = useRef();
    const weight = useRef();
    const selectedBreed = useRef();

    useEffect(()=>{
        if (data.status === 'idle') {
            dispatch(getRegisterData())
        };
    },[])

    const submitData = e => {
        e.preventDefault();
        const veislinis = data.breeds.filter(breed=>breed.Name == selectedBreed.current.value)
        sendData(createDataObject(veislinis.length>0?veislinis[0].Id:null));
    }

    const createDataObject = (breedId) => {
        return {
            Uuid: data.uuid,
            Name: name.current.value,
            BreedID: breedId,
            Age: parseInt(age.current.value),
            Height: parseInt(height.current.value),
            Length: parseInt(length.current.value),
            Weight: parseInt(weight.current.value)
        }
    }

    const sendData = async(data) => {
        try {
            const response = await axios.post('https://localhost:7183/register/create',JSON.stringify(data),{headers:{'Content-Type':'application/json'}});
            dispatch(setRegisterIndexData(response.data));
            navigate(`/preview`);
        } catch (error){
            alert(error.message)
        }
    }

    const renderSwitch = () => {
        switch (data.status) {
            case 'idle':
                return (
                    <h1>Loading...</h1>
                );
            case 'finished':
                return (
                    <>
                    <div className="form-group">
                        <label htmlFor="UUID">UUID:</label>
                        <input className="form-control" type="text" disabled value={data.uuid}/>
                    </div>
                    <div className="form-group">
                        <label htmlFor="name">Name</label>
                        <input className="form-control" type="text" ref={name}/>
                    </div>
                    <div className="form-group">
                        <label htmlFor="breed">Breed</label>
                        <Autocomplete breeds={data.breeds} passedRef={selectedBreed}/>
                    </div>
                    <div className="form-group">
                        <DropSelect passedRef={age} title={'Age'} params={[1,30]} />
                    </div>
                    <div className="form-group">
                        <DropSelect passedRef={height} title={'Height'} params={[1, 150]} />
                    </div>
                    <div className="form-group">
                        <DropSelect passedRef={length} title={'Length'} params={[1, 150]} />
                    </div>
                    <div className="form-group">
                        <DropSelect passedRef={weight} title={'Weight'} params={[1, 100]} />
                    </div>
                    <button className="btn btn-success my-2" type="submit">Register</button>
                    </>
                )
            default:
                break;
        }
    }

    return (
        <form action="" onSubmit={submitData}>
            <h2>Register appointment</h2>
            {renderSwitch()}
        </form>
    )
}