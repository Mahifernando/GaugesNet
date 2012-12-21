GaugesNet
==============

This is a .NET client library for the Gaug.es API. This library is still under development.

Usage
------

            Gauges gauges = new Gauges("token");
            
            gauges.Me();            
            gauges.UpdateMe("Mahi", "Fernando");
            gauges.GetClients();
            gauges.CreateClient("Campfire");
            gauges.DeleteClient("id");
            gauges.GetGauges();
            gauges.CreateGauge("title", "timezone", "www.sample.com,www.anotherdomain.com");
            gauges.GetGauge("id");
            gauges.UpdateGauge("id", "title", "timezone", "www.sample.com");
            gauges..DeleteGauge();
