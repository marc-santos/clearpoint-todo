import { Container, Row, Col, Form, Button, Stack } from 'react-bootstrap';
import React, { useState } from 'react';
import axios from 'axios'


const AddTodoItem = ({ getItems, handleErrorMessage }) => {

    const [description, setDescription] = useState('')

    const handleDescriptionChange = (event) => {
        setDescription(event.target.value)
    }

    function handleClear() {
        setDescription('')
    }

    function generateUUID() {
        // The template string where 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx' will be replaced
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
            var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }

    async function handleAdd() {
        try {
            const response = await axios.post('https://localhost:44397/api/TodoItems', { id: generateUUID(), description: description, isCompleted: false  });
            if (response.status === 200) {
                setDescription('');
                getItems()
            } 
        } catch (error) {
            handleErrorMessage(error.response?.data?.message || 'Failed to add Todo item. Please try again.')
        }
    }

    return (
        <Container>
            <h1>Add Item</h1>
            <Form.Group as={Row} className="mb-3" controlId="formAddTodoItem">
                <Form.Label column sm="2">
                    Description
                </Form.Label>
                <Col md="6">
                    <Form.Control
                        type="text"
                        placeholder="Enter description..."
                        value={description}
                        onChange={handleDescriptionChange}
                    />
                </Col>
            </Form.Group>
            <Form.Group as={Row} className="mb-3 offset-md-2" controlId="formAddTodoItem">
                <Stack direction="horizontal" gap={2}>
                    <Button variant="primary" disabled={!description} onClick={() => handleAdd()}>
                        Add Item
                    </Button>
                    <Button variant="secondary" onClick={() => handleClear()}>
                        Clear
                    </Button>
                </Stack>
            </Form.Group>
        </Container>
    );
};

export default AddTodoItem;
