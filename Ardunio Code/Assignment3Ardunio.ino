int xPin = A4;
int yPin = A5;
int b0Pin = 12;

int xVal;
int yVal;
int b0;

int delayTime = 100;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(xPin, INPUT);
  pinMode(yPin, INPUT);
  pinMode(b0Pin, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  xVal = analogRead(xPin);
  yVal = analogRead(yPin);
  b0 = digitalRead(b0Pin);
  delay(delayTime);

  Serial.print("X=");
  Serial.print(xVal);
  Serial.print(" Y=");
  Serial.print(yVal);
  Serial.print(" b0=");
  Serial.print(b0);
  Serial.println("");
}
