// lib/api.ts
import axios from 'axios';
import { Goal } from '../types/goal';
import { Dispatch } from 'react';
import { updateGoal as updateGoalRedux } from '../store/goalsSlice';

const API_BASE_URL = process.env.REACT_APP_API_URL || 'http://localhost:5000';

/**
 * Sends a PUT request to update a goal on the backend
 * @param goalId - the id of the goal to update
 * @param updates - partial goal object (e.g., { icon: '🤺' })
 * @returns updated goal data
 */
export const updateGoal = async (goalId: string, updates: Partial<Goal>) => {
  try {
    const response = await axios.put(`${API_BASE_URL}/goals/${goalId}`, updates);
    return response.data;
  } catch (error) {
    console.error('Failed to update goal:', error);
    throw error;
  }
};

/**
 * Event handler for emoji selection
 * Updates both local state, Redux store, and persists change to backend
 */
export const pickEmojiOnClick = async (
  emoji: any,
  goalId: string,
  setIcon: (icon: string) => void,
  dispatch: Dispatch<any>
) => {
  try {
    // Update local state immediately
    setIcon(emoji.native);

    // Persist to backend
    const updatedGoal = await updateGoal(goalId, { icon: emoji.native });

    // Update Redux store
    dispatch(updateGoalRedux({ id: goalId, changes: { icon: updatedGoal.icon } }));
  } catch (error) {
    console.error('Error updating goal icon:', error);
  }
};
