import React from "react";
export default function DropSelect({passedRef, title, params, defaultValue}) {
    const [min, max] = params;
    let array = [];
    for (let index = min; index <= max; index++) {
        array.push(<option value={index} key={index}>{index}</option>)
    }
    return (
        <>
            <label htmlFor={title}>{title}</label>
            <select className="form-control" name={title} ref={passedRef} id={title} defaultValue={defaultValue}>
                {array}
            </select>
        </>
    )
}