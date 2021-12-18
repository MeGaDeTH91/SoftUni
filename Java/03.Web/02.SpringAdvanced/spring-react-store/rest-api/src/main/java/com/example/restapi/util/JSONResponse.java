package com.example.restapi.util;

import net.minidev.json.JSONObject;

import java.util.stream.Stream;

public class JSONResponse {
    private static final String MESSAGE_KEY = "message";

    public static JSONObject jsonFromString(String message){
        JSONObject jsonObject = new JSONObject();
        jsonObject.put(MESSAGE_KEY, message);

        return jsonObject;
    }

    public static JSONObject jsonFromStream(Stream<?> message){
        JSONObject jsonObject = new JSONObject();
        jsonObject.put(MESSAGE_KEY, message);

        return jsonObject;
    }
}
