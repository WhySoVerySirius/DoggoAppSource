import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import * as action from './registerActions';
import axios from 'axios';

const initialState = {
  uuid: 0,
  breeds: [],
  status: 'idle',
  error: null,
  selected: null
};

export const getRegisterData = createAsyncThunk('register/getRegisterData', async () => {
    const response = await axios.get('https://localhost:7183/register');
    return response.data;
});

export const registerSlice = createSlice({
    name: 'register',
    initialState,
    // The `reducers` field lets us define reducers and generate associated actions
    reducers: {},
    // The `extraReducers` field lets the slice handle actions defined elsewhere,
    // including actions generated by createAsyncThunk or in other slices.
    extraReducers: (builder) => {
        builder
            .addCase(getRegisterData.pending, (state) => {
               state.status = 'pending'; 
            })
            .addCase(getRegisterData.fulfilled, (state, action) => {
                state.status = 'finished';
                state.uuid = action.payload.Uuid;
                state.breeds = action.payload.Breeds;
            })
            .addCase(getRegisterData.rejected, (state,action) => {
                state.status = 'failed';
                state.error = action.error.message;
            })
            .addCase(action.loadRegisterIndexData,(state) => {
                return state.selected;
            })
            .addCase(action.setRegisterIndexData,(state, action) => {
                state.selected = action.payload;
            })
            .addCase(action.updateRegisterIndexData, (state, action) => {
                state.selected = action.payload;
            })
            .addCase(action.clearRegisterIndexData, (state) => {
                state.selected = null;
            })
    },
});
  


// export const { increment, decrement, incrementByAmount } = counterSlice.actions;

// The function below is called a selector and allows us to select a value from
// the state. Selectors can also be defined inline where they're used instead of
// in the slice file. For example: `useSelector((state: RootState) => state.counter.value)`
export const selectRegisterData = (state) => state.register;

export default registerSlice.reducer;
  