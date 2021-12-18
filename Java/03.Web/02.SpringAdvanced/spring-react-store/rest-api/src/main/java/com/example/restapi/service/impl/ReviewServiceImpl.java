package com.example.restapi.service.impl;

import com.example.restapi.model.entity.Review;
import com.example.restapi.model.service.ReviewServiceModel;
import com.example.restapi.repository.ReviewRepository;
import com.example.restapi.service.ReviewService;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

@Service
public class ReviewServiceImpl implements ReviewService {
    private final ReviewRepository reviewRepository;
    private final ModelMapper modelMapper;

    public ReviewServiceImpl(ReviewRepository reviewRepository, ModelMapper modelMapper) {
        this.reviewRepository = reviewRepository;
        this.modelMapper = modelMapper;
    }

    @Override
    public ReviewServiceModel create(ReviewServiceModel reviewServiceModel) {
        Review review = modelMapper.map(reviewServiceModel, Review.class);

        return modelMapper.map(reviewRepository.saveAndFlush(review), ReviewServiceModel.class);
    }
}
