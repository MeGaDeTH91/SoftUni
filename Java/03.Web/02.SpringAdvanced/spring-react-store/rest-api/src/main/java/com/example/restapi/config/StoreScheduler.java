package com.example.restapi.config;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;

import java.text.SimpleDateFormat;
import java.util.Date;

@Component
public class StoreScheduler {

    private static final Logger log = LoggerFactory.getLogger(StoreScheduler.class);
    private static final SimpleDateFormat dateFormat = new SimpleDateFormat("HH:mm:ss");

    @Scheduled(cron = "${project-cron:0 0/30 * * * ?}")
    public void currentTime() {
        log.info("Cron scheduler: Current Time      = {}", dateFormat.format(new Date()));
    }
}
