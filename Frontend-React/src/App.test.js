import React from 'react';
import { render, screen, waitFor, fireEvent } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import App from './App';


const mock = new MockAdapter(axios);
 
describe('App Component', () => {
  beforeEach(() => {
    mock.reset();
  });

  test('fetches and displays todo items', async () => {
    const items = [{ id: 1, description: 'Test Item', isCompleted: false }];
    mock.onGet('https://localhost:44397/api/TodoItems').reply(200, items);

    render(<App />);

    await waitFor(() => expect(screen.getByText(/Test Item/i)).toBeInTheDocument());
  });

  test('displays an error message on fetch failure', async () => {
    mock.onGet('https://localhost:44397/api/TodoItems').reply(500);

    render(<App />);

    await waitFor(() => expect(screen.getByText(/Failed to fetch Todo items. Please try again./i)).toBeInTheDocument());
  });

});