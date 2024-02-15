import React, { useState, ChangeEvent, FormEvent } from 'react';
import ApiService from "../../Services/ApiService";
import '../CausesForm/AddCauseForm.css';
import AuctionService from "../../Services/AuctionService";
import ApiResponseDTO from "../../Interfaces/DTOs/ApiResponseDTO";
import { useNavigate } from 'react-router-dom';

interface AddAuctionFormProps {
  onClose: () => void;
}

interface FormData {
  name: string;
  description: string;
  isCompleted: boolean;
  photo: File | null;
  startPrice: number;
  existingDays: number;
}

const AddAuctionForm: React.FC<AddAuctionFormProps> = ({ onClose }) => {

  const navigate = useNavigate();
  const [formData, setFormData] = useState<FormData>({
    name: '',
    description: '',
    isCompleted: false,
    photo: null,
    startPrice: 0,
    existingDays: 0,
  });

  const [photoError, setPhotoError] = useState<string>('');
  const [submitted, setSubmitted] = useState<boolean>(false);
  const allowedFileTypes = ['image/jpeg', 'image/png'];
  const apiService = new ApiService();
  const auctionService = new AuctionService(apiService);

  const handleClose = () => {
    onClose();
  };

  const handleInputChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleFileChange = (e: ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];

    if (file) {
      if (allowedFileTypes.includes(file.type)) {
        setFormData((prevData) => ({
          ...prevData,
          photo: file,
        }));
        const reader = new FileReader();
        reader.onloadend = () => {
        };
        reader.readAsDataURL(file);
      } else {
        setFormData((prevData) => ({
          ...prevData,
          photo: null,
        }));
        alert('Invalid file type. Please upload a JPEG or PNG image.');
      }
    } else {
      setFormData((prevData) => ({
        ...prevData,
        photo: null,
      }));
      setSubmitted(false);
    }
  };

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();
    setSubmitted(true);

    if (!formData.photo) {
      setPhotoError('Please upload a photo.');
      return;
    }
    try {
      const response: ApiResponseDTO = await auctionService.createAuction(formData);

      if (response.succeed) {
        console.log('Auction created successfully:', response.data);
        onClose();
        navigate('/auctions');
      } else {
        console.error('Failed to create auction:', response.message);
      }
    } catch (error) {
      console.error('Error creating auction:', error);
      onClose();
      alert(`Error creating auction: `);
    }
  };

  const handleAddAuction = async (e: FormEvent) => {
    e.preventDefault();
    setSubmitted(true);

    if (!formData.photo) {
      setPhotoError('Please upload a photo.');
      return;
    }
    try {
      const updatedCause = await auctionService.createAuction(formData);
      onClose()
      navigate('/auctions');
      location.reload();
    } catch (error) {
      console.error('Error updating cause:', error);
    }
  };

  return (
    <div className="add-cause-form">
      <div className="close-button" onClick={handleClose}>
        <span className="close-cross">&#10005;</span>
      </div>
      <form onSubmit={handleSubmit}>
        <h2 className='create-cause-header'>Create auction</h2>
        <label className='label-create-auction'>
          Auction:
        </label>
        <input
          type="text"
          id="name"
          name="name"
          placeholder="Name"
          value={formData.name}
          onChange={handleInputChange}
          required
        />

        <label className='label-create-auction'>
          Description
        </label>
        <textarea
          className='textarea-description-create-cause'
          id="description"
          name="description"
          placeholder="Description"
          value={formData.description}
          onChange={handleInputChange}
          required
        />
        <label className='label-create-auction'>
          Photo
        </label>

        <input
          type="file"
          id="photo"
          name="photo"
          onChange={handleFileChange}
          accept="image/*"
        />
        {submitted && !formData.photo &&
          <p className='please-upload-photo-p'>
            Please upload a photo.
          </p>}

        <label>
          Start Price:
        </label>
        <div className="input-with-symbol">
          <span className="symbol">BGN</span>
          <input
            className='input-start-price'
            id="startPrice"
            name="startPrice"
            placeholder="Start price"
            value={formData.startPrice}
            onChange={handleInputChange}
            required
          />
        </div>

        <label>
          Existing minutes:
        </label>
        <input
          className='input-exsisting-minutes'
          id="existingDays"
          name="existingDays"
          placeholder="Existing minutes"
          value={formData.existingDays}
          onChange={handleInputChange}
          required
        />

        <button type="submit" className='submit-button-cause' onClick={handleAddAuction}>Submit</button>
      </form>
    </div>
  );
}

export default AddAuctionForm;
