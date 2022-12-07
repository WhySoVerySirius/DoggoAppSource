import React from "react"
import {Link} from 'react-router-dom';
import AppointmentSearch from "../AppointmentSearch";

export default function Layout({children, pages, currentPage}){
    return (
        <>
            <nav className="navbar navbar-expand-md navbar-light bg-light">
                <div className="container-fluid">
                    <a className="navbar-brand">Appointments</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarNav">
                        <ul className="navbar-nav">
                            {
                                pages.map(page=>{
                                    return (
                                        <Link to={page.path} className="nav-item" key={page.title}>
                                            <span className="nav-link">{page.title}</span>
                                        </Link>
                                    )
                                })
                            }
                        </ul>
                    </div>
                    {
                        currentPage === 'Preview'
                            ?(
                                <AppointmentSearch/>
                            )
                            :null
                    }

                </div>
            </nav>
            <div className="container d-flex justify-content-center align-items-center my-3">
                <div className="container border border-primary">
                    {children}
                </div>
            </div>
        </>
    )
}