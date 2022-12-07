import React from "react";
import {Routes, Route} from 'react-router-dom';
import pages from "../pages/pages";
import Layout from "./layout/layout";

export default function Main() {
    return (
        <Routes>
            {
                pages.map(
                    page => {
                        return <Route path={page.path} element={<Layout pages={pages} currentPage={page.title}>{page.element}</Layout>} key={page.title}/>
                    },
                )
            }
        </Routes>
    )
}