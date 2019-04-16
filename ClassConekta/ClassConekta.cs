using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conekta;

namespace ClassConekta
{
    public class ClassConekta
    {

        public void Entrada(){
        
        Api.apiKey = "key_A4yGLnyz6qYnXUw1je5jySA";
        Api.version = "2.0.0";
        Api.locale = "es";

        //System.Console.WriteLine(order);        
        }

    }

    public class ListTest
    {
        public static void getApiKey()
        {
            Api.apiKey = "key_A4yGLnyz6qYnXUw1je5jySA";
        }

        public void getObject()
        {
            getApiKey();
            Api.version = "2.0.0";
            
            conekta.Order order = new Order().create(@"{
                  ""currency"": ""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s a"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }, {
                  ""name"": ""Box of Cohiba S1s b"",
                  ""unit_price"": 36000,
                  ""quantity"": 1
                  }, {
                  ""name"": ""Box of Cohiba S1s c"",
                  ""unit_price"": 37000,
                  ""quantity"": 1
                  }, {
                  ""name"": ""Box of Cohiba S1s d"",
                  ""unit_price"": 38000,
                  ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s e"",
                    ""unit_price"": 39000,
                    ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s f"",
                      ""unit_price"": 40000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s g"",
                      ""unit_price"": 41000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s h"",
                      ""unit_price"": 42000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s i"",
                      ""unit_price"": 43000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s j"",
                      ""unit_price"": 44000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s k"",
                      ""unit_price"": 45000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s l"",
                      ""unit_price"": 46000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s m"",
                      ""unit_price"": 47000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s n"",
                      ""unit_price"": 48000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s ñ"",
                      ""unit_price"": 49000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s o"",
                      ""unit_price"": 50000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s p"",
                      ""unit_price"": 51000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s q"",
                      ""unit_price"": 52000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s r"",
                      ""unit_price"": 53000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s s"",
                      ""unit_price"": 54000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s t"",
                      ""unit_price"": 55000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s u"",
                      ""unit_price"": 56000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s v"",
                      ""unit_price"": 57000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s w"",
                      ""unit_price"": 58000,
                      ""quantity"": 1
                  }, {
                    ""name"": ""Box of Cohiba S1s x"",
                      ""unit_price"": 59000,
                      ""quantity"": 1
                  }]
            }");

            LineItem line_item = (LineItem)order.line_items.at(0);

            int size = order.line_items.data.Length;

            order.line_items.next_page();

            Assert.AreEqual(order.line_items.data.Length > size, true);
        }
    }


    public class OrderTest
    {
        public static void getApiKey()
        {
            Api.apiKey = "key_A4yGLnyz6qYnXUw1je5jySA";
        }
        private int RandomNumber(int min, int max, int seed = 0)
        {
            Random random = new Random((int)DateTime.Now.Ticks + seed);
            return random.Next(min, max);
        }


        public void apiVersionUnsupported()
        {
            getApiKey();
            Api.version = "0.3.0";

            try
            {
                new conekta.Order().create(@"{
                    ""currency"":""MXN"",
                    ""customer_info"": {
                    ""name"": ""Jul Ceballos"",
                    ""phone"": ""+5215555555555"",
                    ""email"": ""jul@conekta.io""
                    }
                    }");
            }
            catch (ConektaException e)
            {
                Assert.AreEqual(e._object, "error");
                Assert.AreEqual(e._type, "api_version_unsupported");
            }
        }


        public void createCard()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }],
                  ""charges"": [{
                  ""payment_method"": {
                  ""type"": ""card"",
                  ""token_id"": ""tok_test_visa_4242""
                  }
                  }],
                  ""metadata"": {
                  ""yes"": ""nou""
                  }
            }");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");
            Assert.AreEqual(order.payment_status, "paid");
            Assert.AreEqual(order.amount, 35000);

            Charge charge = (Charge)order.charges.at(0);
            Assert.AreEqual(charge.payment_method.brand, "visa");

            order = new Order().find(order.id);

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");
            Assert.AreEqual(order.payment_status, "paid");
            Assert.AreEqual(order.amount, 35000);

            order = order.createReturn(@"{""amount"": 35000}");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");
            Assert.AreEqual(order.payment_status, "refunded");
            Assert.AreEqual(order.amount, 35000);

            Order[] orders = new Order().where(new JObject());
            Assert.AreEqual(orders[0].id.GetType().ToString(), "System.String");

        }

        
        public void createCharge()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                      ""currency"":""MXN"",
                      ""customer_info"": {
                      ""name"": ""Jul Ceballos"",
                      ""phone"": ""+5215555555555"",
                      ""email"": ""jul@conekta.io""
                      },
                      ""line_items"": [{
                      ""name"": ""Box of Cohiba S1s"",
                      ""unit_price"": 35000,
                      ""quantity"": 1
                      }]
                      }");

            order.createCharge(@"{
                    ""payment_method"": {
                    ""type"": ""card"",
                    ""token_id"": ""tok_test_visa_4242""
                    },
                    ""amount"": 35000
                    }");

            order = new Order().find(order.id);

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");
            Assert.AreEqual(order.payment_status, "paid");
            Assert.AreEqual(order.amount, 35000);

            order = new Order().find(order.id);

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");
            Assert.AreEqual(order.payment_status, "paid");
            Assert.AreEqual(order.amount, 35000);

            order = order.createReturn(@"{""amount"": 35000}");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");
            Assert.AreEqual(order.payment_status, "refunded");
            Assert.AreEqual(order.amount, 35000);

            Order[] orders = new Order().where(new JObject());
            Assert.AreEqual(orders[0].id.GetType().ToString(), "System.String");
        }


     
        public void captureCharge()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }],
                  ""pre_authorize"": true
                  }");

            order.createCharge(@"{
                ""payment_method"": {
                ""type"": ""card"",
                ""token_id"": ""tok_test_visa_4242""
                },
                ""amount"": 35000
                }");

            order = new Order().find(order.id);

            order = order.capture();

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");
            Assert.AreEqual(order.payment_status, "paid");
            Assert.AreEqual(order.amount, 35000);
        }

     
        public void createCardError()
        {
            getApiKey();
            Api.version = "2.0.0";

            try
            {
                new conekta.Order().create(@"{
                    ""currency"":""MXN"",
                    ""customer_info"": {
                    ""name"": ""Jul Ceballos"",
                    ""phone"": ""+5215555555555"",
                    ""email"": ""jul@conekta.io""
                    }
                    }");
            }
            catch (ConektaException e)
            {
                Assert.AreEqual(e._object, "error");
                Assert.AreEqual(e._type, "parameter_validation_error");
            }
        }

 
        public void CreateOxxo()
        {
            getApiKey();
            Api.version = "2.0.0";


            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }],
                  ""charges"": [{
                  ""payment_method"": {
                  ""type"": ""oxxo_cash"",
                  ""expires_at"": 1553273553
                  },
                  ""amount"": 35000
                  }]
                  }");
            Assert.AreEqual(order.id.GetType().ToString(), "System.String");
            System.Console.WriteLine(order.payment_status);
            Assert.AreEqual(order.payment_status, "pending_payment");
            Assert.AreEqual(order.amount, 35000);
        }

        
        public void update()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }]
                  }");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");
            Assert.AreEqual(order.amount, 35000);

            order = new Order().find(order.id);

            order = order.update(@"{""currency"": ""USD""}");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");
            Assert.AreEqual(order.amount, 35000);
        }

       
        public void createLineItem()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }]
                  }");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");

            order = new Order().find(order.id);

            LineItem line_item = order.createLineItem(@"{
                ""name"": ""Box of Cohiba S1s"",
                ""unit_price"": 35000,
                ""quantity"": 1
                }");

            Assert.AreEqual(line_item.name, "Box of Cohiba S1s");
        }

        
        public void updateLineItem()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }]
                  }");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");

            order = new Order().find(order.id);

            LineItem line_item = (LineItem)order.line_items.at(0);

            //line_item = line_item.update(@"{
            //  ""name"": ""Box S1s"",
            //  ""unit_price"": 45000
            //}");

            //Assert.AreEqual(line_item.name, "Box S1s");

        }

    
        public void createTaxLine()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }]
                  }");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");

            order = new Order().find(order.id);

            TaxLine tax_line = order.createTaxLine(@"{
                ""description"": ""IVA"",
                ""amount"": 600,
                ""metadata"": {
                ""random_key"": ""random_value""
                }
                }");

            Assert.AreEqual(tax_line.description, "IVA");
            Assert.AreEqual(tax_line.amount, 600);
        }

        
        public void updateTaxLine()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1,
                  ""metadata"": {
                  ""random_key"": ""random value""
                  }
                  }]
                  }");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");

            order = new Order().find(order.id);

            TaxLine tax_line = order.createTaxLine(@"{
                ""description"": ""IVA"",
                ""amount"": 600,
                ""contextual_data"": {
                ""random_key"": ""random_value""
                }
                }");

            order = new Order().find(order.id);

            //tax_line = order.tax_lines.at(0).update(@"{
            //   ""description"": ""IVA"",
            //   ""amount"": 1000,
            //   ""contextual_data"": {
            //      ""random_key"": ""random_value""
            //   }
            //}");

            //System.Console.WriteLine(tax_line.amount);

            //Assert.AreEqual(tax_line.description, "IVA");
            //Assert.AreEqual(tax_line.amount, 1000);
        }

       
        public void createShippingLine()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }]
                  }");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");

            order = new Order().find(order.id);

            ShippingLine shipping_line = order.createShippingLine(@"{
                ""amount"": 0,
                ""tracking_number"": ""TRACK123"",
                ""carrier"": ""USPS"",
                ""method"": ""Train"",
                ""metadata"": {
                ""random_key"": ""random_value""
                }
                }");

            Assert.AreEqual(shipping_line.tracking_number, "TRACK123");
        }

       
        public void updateShippingLine()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }]
                  }");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");

            order = new Order().find(order.id);

            ShippingLine shipping_line = order.createShippingLine(@"{
                ""amount"": 0,
                ""tracking_number"": ""TRACK123"",
                ""carrier"": ""Fedex"",
                ""method"": ""Train"",
                ""contextual_data"": {
                ""random_key"": ""random_value""
                }
                }");

            order = new Order().find(order.id);

            shipping_line = (ShippingLine)order.shipping_lines.at(0);
            shipping_line = shipping_line.update(@"{
                ""carrier"": ""UPS""
                }");

            Assert.AreEqual(shipping_line.carrier, "UPS");
        }

        public void createDiscountLine()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""+5215555555555"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }]
                  }");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");

            order = new Order().find(order.id);

            DiscountLine discount_line = order.createDiscountLine(@"{
                ""code"": ""123"",
                ""type"": ""loyalty"",
                ""amount"": 600
                }");

            Assert.AreEqual(discount_line.code, "123");
            Assert.AreEqual(discount_line.type, "loyalty");
        }

     
        public void updateDiscountLine()
        {
            getApiKey();
            Api.version = "2.0.0";

            Order order = new conekta.Order().create(@"{
                  ""currency"":""MXN"",
                  ""customer_info"": {
                  ""name"": ""Jul Ceballos"",
                  ""phone"": ""5575553324"",
                  ""email"": ""jul@conekta.io""
                  },
                  ""line_items"": [{
                  ""name"": ""Box of Cohiba S1s"",
                  ""unit_price"": 35000,
                  ""quantity"": 1
                  }]
                  }");

            Assert.AreEqual(order.id.GetType().ToString(), "System.String");

            order = new Order().find(order.id);

            DiscountLine discount_line = order.createDiscountLine(@"{
                ""code"": ""234"",
                ""type"": ""loyalty"",
                ""amount"": 600
                }");

            order = new Order().find(order.id);

            discount_line = (DiscountLine)order.discount_lines.at(0);
            discount_line = discount_line.update(@"{
                ""amount"": 700,
                ""code"": ""567"",
                ""type"": ""coupon""
                }");

            Assert.AreEqual(discount_line.type, "coupon");
            Assert.AreEqual(discount_line.code, "567");
            Assert.AreEqual(discount_line.amount, 700);
        }
    }

    
    public class CustomerTest
    {

        public static void getApiKey()
        {
            Api.apiKey = "key_A4yGLnyz6qYnXUw1je5jySA";
        }

      
        public void createCustomer()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com"",
                  ""plan_id"": ""gold-plan"",
                  ""corporate"": true,
                  ""payment_sources"": [{
                  ""token_id"": ""tok_test_visa_4242"",
                  ""type"": ""card""
                  }],
                  ""shipping_contacts"": [{
                  ""phone"": ""+5215555555555"",
                  ""receiver"": ""Marvin Fuller"",
                  ""between_streets"": ""Ackerman Crescent"",
                  ""address"": {
                  ""street1"": ""250 Alexis St"",
                  ""street2"": ""fake street"",
                  ""city"": ""Red Deer"",
                  ""state"": ""Alberta"",
                  ""country"": ""CA"",
                  ""postal_code"": ""T4N 0B8"",

                  ""residential"": true
                  }

                  }],
                  ""antifraud_info"": {
                    ""account_age"": 300,
                    ""paid_transactions"": 5
                  }
            }");

            Assert.AreEqual(customer.corporate, true);

            customer = new Customer().find(customer.id);

            Assert.AreEqual(customer.corporate, true);
            Assert.IsNotNull(customer.created_at);
        }

       
        public void updateCustomer()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""5575553322"",
                  ""email"": ""user@example.com"",
                  ""corporate"": true
                  }");

            Assert.AreEqual(customer.corporate, true);
            Assert.AreEqual(customer.name, "Emiliano Cabrera");

            customer = new Customer().find(customer.id);

            Assert.AreEqual(customer.corporate, true);
            Assert.AreEqual(customer.name, "Emiliano Cabrera");

            customer = customer.update(@"{
                ""corporate"": false,
                ""name"": ""Juan Perez""
                }");

            Assert.AreEqual(customer.name, "Juan Perez");
            Assert.AreEqual(customer.corporate, false);
        }

     
        public void deleteCustomer()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com"",
                  ""plan_id"": ""gold-plan"",
                  ""corporate"": true,
                  ""payment_sources"": [{
                  ""token_id"": ""tok_test_visa_4242"",
                  ""type"": ""card""
                  }]
                  }");

            Assert.AreEqual(customer.corporate, true);

            customer = new Customer().find(customer.id);

            Assert.AreEqual(customer.corporate, true);

            customer = customer.destroy();

            Assert.AreEqual(customer.corporate, true);
        }

  
        public void createCustomerWithOfflineRecurrentReference()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com"",
                  ""corporate"": true,
                  ""payment_sources"": [{
                    ""expires_at"": 1553273553,
                    ""type"": ""oxxo_recurrent""
                  }]
                  }");

            PaymentSource paymentSource = customer.payment_sources[0];
            OfflineRecurrentReference reference = paymentSource as OfflineRecurrentReference;

            Assert.IsNotNull(reference.reference);
            Assert.IsNotNull(reference.barcode);
            Assert.IsNotNull(reference.barcode_url);
            Assert.IsNotNull(reference.provider);
            Assert.AreEqual(reference.expires_at, "1553273553");
        }

   
        public void createCustomerWithCard()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com"",
                  ""plan_id"": ""gold-plan"",
                  ""corporate"": true,
                  ""payment_sources"": [{
                      ""token_id"": ""tok_test_visa_4242"",
                      ""type"": ""card""
                  }]
                  }");

            PaymentSource paymentSource = customer.payment_sources[0];

            Card card = paymentSource as Card;
            Assert.AreEqual(customer.corporate, true);

        }

    
        public void createSubscription()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com"",
                  ""corporate"": true,
                  ""payment_sources"": [{
                  ""token_id"": ""tok_test_visa_4242"",
                  ""type"": ""card""
                  }]
                  }");

            Subscription subscription = customer.createSubscription(@"{
                ""plan"": ""gold-plan""
                }");

            Assert.AreEqual(subscription.plan_id, "gold-plan");
        }

  
        public void updateSubscription()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com"",
                  ""corporate"": true,
                  ""payment_sources"": [{
                  ""token_id"": ""tok_test_visa_4242"",
                  ""type"": ""card""
                  }]
                  }");

            Subscription subscription = customer.createSubscription(@"{
                ""plan"": ""gold-plan""
                }");

            Assert.AreEqual(subscription.plan_id, "gold-plan");

            subscription = subscription.update(@"{
                ""plan"": ""opal-plan""
                }");

            Assert.AreEqual(subscription.plan_id, "opal-plan");
        }

        public void statesSubscription()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com"",
                  ""corporate"": true,
                  ""payment_sources"": [{
                  ""token_id"": ""tok_test_visa_4242"",
                  ""type"": ""card""
                  }]
                  }");

            Subscription subscription = customer.createSubscription(@"{
                ""plan"": ""gold-plan""
                }");

            Assert.AreEqual(subscription.status, "in_trial");

            subscription = subscription.pause();

            Assert.AreEqual(subscription.status, "paused");

            subscription = subscription.resume();

            Assert.AreEqual(subscription.status, "in_trial");

            subscription = subscription.cancel();

            Assert.AreEqual(subscription.status, "canceled");
        }

        public void createCard()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com"",
                  ""corporate"": true,
                  ""payment_sources"": []
                  }");

            Card card = (Card)customer.CreateCard(@"{
                ""token_id"": ""tok_test_visa_4242"",
                ""type"": ""card""
                }");

            Assert.AreEqual(card.type, "card");
            Assert.AreEqual(card.name, "Jorge Lopez");
        }

        public void createOfflineRecurrentReference()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                      ""name"": ""Emiliano Cabrera"",
                      ""phone"": ""+5215544443333"",
                      ""email"": ""user@example.com"",
                      ""corporate"": true,
                      ""payment_sources"": []
                      }");

            OfflineRecurrentReference reference = (OfflineRecurrentReference)customer.CreateOfflineRecurrentReference(@"{
                    ""expires_at"": 1553273553,
                    ""type"": ""oxxo_recurrent""
                    }");

            Assert.IsNotNull(reference.reference);
            Assert.IsNotNull(reference.barcode);
            Assert.IsNotNull(reference.barcode_url);
            Assert.IsNotNull(reference.provider);
            Assert.AreEqual(reference.expires_at, "1553273553");
        }

        public void updatePaymentSource()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com"",
                  ""corporate"": true
                  }");

            Card payment_source = (Card)customer.CreateCard(@"{
                ""token_id"": ""tok_test_visa_4242"",
                ""type"": ""card""
                }");

            Card updatedPaymentSource = payment_source.Update(@"{
                ""name"": ""Emiliano Suarez""
                }");

            Assert.AreEqual(updatedPaymentSource.name, "Emiliano Suarez");
        }

        public void deletePaymentSource()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com""
                  }");

            PaymentSource payment_source = customer.CreateCard(@"{
                ""token_id"": ""tok_test_visa_4242"",
                ""type"": ""card""
                }");

            payment_source.destroy();

            Customer customerReloaded = new Customer().find(customer.id);



            Assert.AreEqual(customerReloaded.payment_sources, null);
        }

        public void createShippingContact()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com"",
                  ""plan_id"": ""gold-plan"",
                  ""corporate"": true,
                  ""payment_sources"": [{
                  ""token_id"": ""tok_test_visa_4242"",
                  ""type"": ""card""
                  }],
                  ""shipping_contacts"": [{
                  ""email"": ""thomas.logan@xmen.org"",
                  ""phone"": ""+5215555555555"",
                  ""receiver"": ""Marvin Fuller"",
                  ""between_streets"": ""Ackerman Crescent"",
                  ""address"": {
                  ""street1"": ""250 Alexis St"",
                  ""street2"": ""fake street"",
                  ""city"": ""Red Deer"",
                  ""state"": ""Alberta"",
                  ""country"": ""CA"",
                  ""postal_code"": ""T4N 0B8"",
                  ""residential"": true
                  }
                  }],
                  ""account_age"": 300,
                  ""paid_transactions"": 5
            }");

            ShippingContact shipping_contact = customer.createShippingContact(@"{
                ""phone"": ""+5215555555555"",
                ""receiver"": ""Marvin Fuller"",
                ""between_streets"": ""Ackerman Crescent"",
                ""address"": {
                ""street1"": ""250 Alexis St"",
                ""street2"": ""fake street"",
                ""city"": ""Red Deer"",
                ""state"": ""Alberta"",
                ""country"": ""CA"",
                ""postal_code"": ""T4N 0B8"",
                ""residential"": true
                }
                }");

            Assert.AreEqual(shipping_contact.phone, "+5215555555555");
        }

        public void updateShippingContact()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""5575553322"",
                  ""email"": ""user@example.com"",
                  ""corporate"": true
                  }");

            ShippingContact shipping_contact = customer.createShippingContact(@"{
                ""phone"": ""5575553322"",
                ""receiver"": ""Marvin Fuller"",
                ""between_streets"": ""Ackerman Crescent"",
                ""address"": {
                ""street1"": ""250 Alexis St"",
                ""street2"": ""fake street"",
                ""city"": ""Red Deer"",
                ""state"": ""Alberta"",
                ""country"": ""CA"",
                ""postal_code"": ""T4N 0B8"",
                ""residential"": true
                }
                }");

            shipping_contact = shipping_contact.update(@"{
                ""phone"": ""5575553324""
                }");

            Assert.AreEqual(shipping_contact.phone, "5575553324");
        }

        public void deleteShippingContact()
        {
            getApiKey();
            Api.version = "2.0.0";

            Customer customer = new conekta.Customer().create(@"{
                  ""name"": ""Emiliano Cabrera"",
                  ""phone"": ""+5215544443333"",
                  ""email"": ""user@example.com"",
                  ""corporate"": true
                  }");

            ShippingContact shipping_contact = customer.createShippingContact(@"{
                ""phone"": ""+5215555555555"",
                ""receiver"": ""Marvin Fuller"",
                ""between_streets"": ""Ackerman Crescent"",
                ""address"": {
                ""street1"": ""250 Alexis St"",
                ""street2"": ""fake street"",
                ""city"": ""Red Deer"",
                ""state"": ""Alberta"",
                ""country"": ""CA"",
                ""postal_code"": ""T4N 0B8"",
                ""residential"": true
                }
                }");

            Assert.AreEqual(shipping_contact.phone, "+5215555555555");

            shipping_contact = shipping_contact.update(@"{
                ""phone"": ""+5215555555555""
                }");

            Assert.AreEqual(shipping_contact.phone, "+5215555555555");

            shipping_contact = shipping_contact.destroy();

            Assert.AreEqual(shipping_contact.phone, "+5215555555555");
        }
    }
    /*
    public class EventTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        public static void getApiKey()
        {
            Api.apiKey = "key_A4yGLnyz6qYnXUw1je5jySA";
        }

        public void EventList()
        {
            getApiKey();
            Api.version = "2.0.0";
            Event[] events = new Event().where(new JObject());


            Assert.AreEqual(events[0].webhook_status.GetType().ToString(), "System.String");
            Assert.AreEqual(events[0].created_at.GetType().ToString(), "System.String");
            Assert.AreEqual(events[0].livemode.GetType().ToString(), "System.String");
            Assert.AreEqual(events[0].id.GetType().ToString(), "System.String");
        }
    }
    */
    public class ChargeTest
    {

        private int RandomNumber(int min, int max, int seed = 0)
        {
            Random random = new Random((int)DateTime.Now.Ticks + seed);
            return random.Next(min, max);
        }

        public void Card()
        {
            Api.locale = "es";
            Api.apiKey = "key_eYvWV7gSDkNYXsmr";
            Api.version = "1.0.0";

            conekta.Charge charge = new conekta.Charge().create(@"{
                    ""description"":""Stogies"",
                    ""amount"": 20000,
                    ""currency"":""MXN"",
                    ""reference_id"":""9839-wolf_pack"",
                    ""card"": ""tok_test_visa_4242"",
                    ""details"": {
                      ""name"": ""Arnulfo Quimare"",
                      ""phone"": ""403-342-0642"",
                      ""email"": ""logan@x-men.org"",
                      ""customer"": {
                        ""logged_in"": true,
                        ""successful_purchases"": 14,
                        ""created_at"": 1379784950,
                        ""updated_at"": 1379784950,
                        ""offline_payments"": 4,
                        ""score"": 9
                      },
                      ""line_items"": [{
                        ""name"": ""Box of Cohiba S1s"",
                        ""description"": ""Imported From Mex."",
                        ""unit_price"": 20000,
                        ""quantity"": 1,
                        ""sku"": ""cohb_s1"",
                        ""category"": ""food""
                      }],
                      ""billing_address"": {
                        ""street1"":""77 Mystery Lane"",
                        ""street2"": ""Suite 124"",
                        ""street3"": null,
                        ""city"": ""Darlington"",
                        ""state"":""NJ"",
                        ""zip"": ""10192"",
                        ""country"": ""Mexico"",
                        ""tax_id"": ""xmn671212drx"",
                        ""company_name"":""X-Men Inc."",
                        ""phone"": ""77-777-7777"",
                        ""email"": ""purshasing@x-men.org""
                      }
                    },
              ""capture"": false
                  }");

            Assert.AreEqual(charge.payment_method.type, "credit");
            Assert.AreEqual(charge.id.GetType().ToString(), "System.String");
            Assert.AreEqual(charge.amount, 20000);

            charge = new Charge().find(charge.id);

            Assert.AreEqual(charge.id.GetType().ToString(), "System.String");
            Assert.AreEqual(charge.amount, 20000);

            charge = charge.capture();

            Assert.AreEqual(charge.id.GetType().ToString(), "System.String");
            Assert.AreEqual(charge.amount, 20000);

            charge = charge.refund();

            Assert.AreEqual(charge.id.GetType().ToString(), "System.String");
            Assert.AreEqual(charge.amount, 20000);
        }


    }

}
