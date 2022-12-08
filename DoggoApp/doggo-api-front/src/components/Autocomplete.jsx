import React from "react";
import { useState } from "react";
import BreedInfo from "./BreedInfo";

export default function Autocomplete({breeds, passedRef, currentBreed}) {

    const [input, setInput] = useState(currentBreed!=null?currentBreed.breed.name:'');
    const [clicked, setClicked] = useState(false);

    const filteredBreeds = input != ''
        ?breeds.filter(breed=> breed.Name.toLowerCase().includes(input.toLowerCase()))
        :[];

    const selectBreed = (name) => {
        setInput(name);
        setClicked(!clicked);
    }
    const renderSwitch = () => {
        switch (input) {
            case '':
                break;
            default:
                const options = filteredBreeds.map(
                    breed => {
                        return <div className="table-hover border border-secondary my-1 p-1 hover" onClick={()=>selectBreed(breed.Name)} key={breed.Name}>{breed.Name}</div>
                    }
                );
                return options.length>0
                    ?(
                        <>
                            {
                            clicked === false && options.length > 0 && input != options[0].props.children
                                ?<div style={{height:'300px', overflowY:'scroll'}}>
                                    {options?options:null}
                                </div>
                                :null
                            }
                            {
                                input === options[0].props.children
                                    ?<BreedInfo selectedBreed={options[0].props.children}/>
                                    :null
                            }
                        </>
                    )
                    :<></>
        }
    }
    
    return (
        <>
        <input type="text" className="form-control" ref={passedRef} onChange={(e)=>{setInput(e.target.value);setClicked(false)}} value={input}></input>
        {renderSwitch()}
        </>
    )
}