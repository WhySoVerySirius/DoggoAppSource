import React, {useRef, useEffect, useState} from "react";
import { useDispatch, useSelector } from "react-redux";
import { getRegisterData, selectRegisterData } from "../features/register/registerSlice";
import Autocomplete from "./Autocomplete";
import DropSelect from "./DropSelect";
import axios from 'axios';
import { clearRegisterIndexData, updateRegisterIndexData } from "../features/register/registerActions";
import CompareGraph from "./CompareGraph";
import { current } from "@reduxjs/toolkit";

export default function Preview() {
    const {selected, breeds, status} = useSelector(selectRegisterData);
    const [abort, setAbort] = useState(false);
    const name = useRef();
    const age = useRef();
    const height = useRef();
    const length = useRef();
    const weight = useRef();
    const selectedBreed = useRef();
    const dispatch = useDispatch();

    useEffect(()=>{
        if (    status === 'idle') {
            dispatch(getRegisterData())
        };
    },[])


    const createUpdateObject = (breedId) => {
        return {
            Id : selected.id,
            Uuid : selected.uuid,
            Name : name.current.value,
            BreedID : breedId,
            Age: parseInt(age.current.value),
            Height: parseInt(height.current.value),
            Length: parseInt(length.current.value),
            Weight: parseInt(weight.current.value)
        }
    }

    const cancelAppointment = async () => {
        try {
            const response = await axios.delete(`https://localhost:7183/preview/delete/${selected.uuid}`,{headers: {'Content-Type':'application/json'},data: JSON.stringify(selected)});
            alert('Appointment canceled');
            dispatch(clearRegisterIndexData())
        } catch (error) {
            alert(error.message)
        }
    }

    const updateAppointment = async (data) => {
        try {
            const response = await axios.put(`https://localhost:7183/preview/edit/${selected.uuid}`,JSON.stringify(data),{headers:{'Content-Type':'application/json'}});
            dispatch(updateRegisterIndexData(response.data));
        } catch (error) {
            alert(error)
        }
    }

    const sendUpdateData = e => {
        e.preventDefault();
        const veislinis = breeds.filter(breed=>breed.Name == selectedBreed.current.value)
        updateAppointment(createUpdateObject(veislinis.length>0?veislinis[0].Id:null));
    }

    const compareData =()=> {
        if (selected === null) return null;
        return {
            selected: {
                weight: selected.weight,
                height: selected.height
            },
            breed : selected.breed
        }
    }

    return selected != null
        ?(
            <div className="container">
                <h2>Inspect appointment</h2>
                <form onSubmit={sendUpdateData} key={selected.id+abort}>
                    <div className="form-group">
                                <label htmlFor="UUID">UUID:</label>
                                <input className="form-control" type="text" disabled value={selected.uuid} readOnly/>
                            </div>
                            <div className="form-group">
                                <label htmlFor="name">Name</label>
                                <input className="form-control" type="text" ref={name} defaultValue={selected.name}/>
                            </div>
                            <div className="form-group">
                                <label htmlFor="breed">Breed</label>
                                <Autocomplete breeds={breeds} passedRef={selectedBreed} currentBreed={selected.breed!=null?selected:null}/>
                            </div>
                            {
                                selected.breed !== null
                                    ?<div className="form-group">
                                        <CompareGraph current={compareData()}/>
                                    </div>
                                    :null
                            }
                            <div className="form-group">
                                <DropSelect passedRef={age} title={'Age'} params={[1,30]} defaultValue={selected.age}/>
                            </div>
                            <div className="form-group">
                                <DropSelect passedRef={height} title={'Height'} params={[1, 150]} defaultValue={selected.height}/>
                            </div>
                            <div className="form-group">
                                <DropSelect passedRef={length} title={'Length'} params={[1, 150]} defaultValue={selected.length}/>
                            </div>
                            <div className="form-group">
                                <DropSelect passedRef={weight} title={'Weight'} params={[1, 100]} defaultValue={selected.weight}/>
                            </div>
                            <button className="btn btn-success my-2" type="submit">Save changes</button>
                            <input type='button' className="btn btn-danger my-2 ms-1" value={'Cancel appointment'} onClick={()=>cancelAppointment()}/>
                            <input type='button' className="btn btn-warning my-2 ms-1" value={'Abort changes'} onClick={()=>setAbort(!abort)}/>
                </form>
            </div>
        )
        :<h2>No appointment selected</h2>
}