import { createAction } from "@reduxjs/toolkit";
import * as actionType from './registerConstants';

export const setRegisterIndexData = createAction(actionType.SET_REGISTER_INDEX_DATA);
export const clearRegisterIndexData = createAction(actionType.CLEAR_REGISTER_INDEX_DATA);
export const updateRegisterIndexData = createAction(actionType.UPDATE_REGISTER_INDEX_DATA);
export const loadRegisterIndexData = createAction(actionType.LOAD_REGISTER_INDEX_DATA);