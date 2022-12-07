import React from "react";
import { useRef } from "react";
import { useDispatch } from "react-redux";
import axios from 'axios';
import { clearRegisterIndexData, setRegisterIndexData } from "../features/register/registerActions";

export default function AppointmentSearch() {

    const dispatch = useDispatch();
    const uuid = useRef();

    const appointmentSearch = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.get(`https://localhost:7183/preview/details/${parseInt(uuid.current.value)}`);
            dispatch(clearRegisterIndexData());
            dispatch(setRegisterIndexData(response.data));
        } catch (error) {
            alert(error)
        }
    }

    return (
        <form className="d-flex" onSubmit={appointmentSearch}>
            <input className="form-control me-2" type="search" placeholder="Search by uuid" aria-label="Search" ref={uuid}/>
            <button className="btn btn-outline-success" type="submit">Search</button>
        </form>
    )
}   