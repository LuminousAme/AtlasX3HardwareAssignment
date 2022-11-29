//input pins 
int xPin = A4;
int yPin = A5;
int b0Pin = A0;
int b1Pin = A1;

//output pins
int redLEDPin = 5;
int greenLEDPin = 3;
int blueLEDPin = 6;

//input values
int xVal;
int yVal;
int b0;
int b1;

//delay time in milliseconds
int delayTime = 100;

void setup() {
  //launch the serial monitor
  Serial.begin(9600);

  //set up all of the input pins
  pinMode(xPin, INPUT);
  pinMode(yPin, INPUT);
  pinMode(b0Pin, INPUT);
  pinMode(b1Pin, INPUT);

  //setup all of the output pins
  pinMode(redLEDPin, OUTPUT);
  pinMode(greenLEDPin, OUTPUT);
  pinMode(blueLEDPin, OUTPUT);

  digitalWrite(redLEDPin, HIGH);
}

void loop() {
  //read the input
  xVal = analogRead(xPin);
  yVal = analogRead(yPin);
  b0 = analogRead(b0Pin);
  b1 = analogRead(b1Pin);

  //insert a delay to make things run more smoothly
  delay(delayTime);

  //write the input to the serial monitor so other apps can read it
  Serial.print("X=");
  Serial.print(xVal);
  Serial.print(" Y=");
  Serial.print(yVal);
  Serial.print(" b0=");
  Serial.print(b0);
  Serial.print(" b1=");
  Serial.print(b1);
  Serial.println("");

  if(b0 > 512) { 
    digitalWrite(blueLEDPin, HIGH);
  }
  else {
    digitalWrite(blueLEDPin, LOW);
  }

  if(b1 > 512) { 
    digitalWrite(greenLEDPin, HIGH);
  }
  else {
    digitalWrite(greenLEDPin, LOW);
  }

  //display the joystick input via the brightness of 4 leds
}

