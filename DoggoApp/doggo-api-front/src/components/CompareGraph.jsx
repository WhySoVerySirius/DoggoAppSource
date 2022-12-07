import React from "react";
import { LineChart, Line, CartesianGrid, XAxis, YAxis, Legend, Tooltip } from 'recharts';

export default function CompareGraph({current}) {
    if (current.breed.height === 'NaN' || current.breed.weight === 'NaN') return null;
    const weightArray = current.breed.weight.split(' - ');
    const heightArray = current.breed.height.split(' - ');

    const returnHighest = (arr) => {
        return arr.sort((a,b) => a-b).pop();
    };

    const topValueArray = [
        current.selected.weight,
        current.selected.height,
        parseInt(weightArray[1]),
        parseInt(heightArray[1])
    ]
    const data = [
        {name: '', top: returnHighest(topValueArray)+10},
        {name: 'Weight(kg)',normalHigh: parseInt(weightArray[1]),normalLow: weightArray[0], current: current.selected.weight, pv: 2400, amt: 2400},
        {name: 'Height(cm)',normalHigh: parseInt(heightArray[1]),normalLow: heightArray[0], current: current.selected.height, pv: 2400, amt: 2400},
        {name: '', pv: 2400, amt: 2400}
    ];

    return (
        <LineChart width={600} height={300} data={data}>
            <Tooltip wrapperStyle={{ width: 150, backgroundColor: '#ccc' }} />
            {/* <Legend width={100} wrapperStyle={{ top: 0, right: 0, backgroundColor: '#f5f5f5', border: '1px solid #d5d5d5', borderRadius: 3, lineHeight: '40px' }} /> */}
            <Line type="monotone" dataKey="current" stroke="#8884d8" />
            <Line type="monotone" dataKey="normalHigh" stroke="#E84F1A" />
            <Line type="monotone" dataKey="normalLow" stroke="#1DE81A" />
            <Line type="monotone" dataKey="top" stroke="#8884d8" />
            <CartesianGrid stroke="#ccc" />
            <XAxis dataKey="name" />
            <YAxis />
        </LineChart>
    )
}