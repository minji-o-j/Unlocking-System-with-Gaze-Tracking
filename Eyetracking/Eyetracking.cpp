#include "opencv2/opencv.hpp"
#include <iostream>
#include <opencv2/core/mat.hpp>
#include <opencv2/imgcodecs.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/highgui.hpp>
#include<iostream>
#include<fstream>
#include<cstring>
#include<string>
#include <time.h>
#include <io.h>

using namespace cv;
using namespace std;
vector<Vec3f> circles;

void sharpen2D(const cv::Mat &image, cv::Mat &result) {

	cv::Mat kernel(3, 3, CV_32F, cv::Scalar(0));

	// 커널 생성(모든 값을 0으로 초기화)

	kernel.at<float>(1, 1) = 5.0; // 커널 값에 할당

	kernel.at<float>(0, 1) = -1.0;

	kernel.at<float>(2, 1) = -1.0;

	kernel.at<float>(1, 0) = -1.0;

	kernel.at<float>(1, 2) = -1.0;



	cv::filter2D(image, result, image.depth(), kernel);

};

int main(int, char**)
{
	VideoCapture cap1(0);//웹캠
	VideoCapture cap2(1);//usb캠
	ifstream changeState;
	ofstream ofile1;
	ofstream ofile2;
	ofstream ofile3;
	ofstream t1;
	ofstream t2;
	clock_t starttime;

	int sum_x = 0;
	int sum_y = 0;
	int n = 0;
	int state = 0;
	bool state2 = 0;
	if (!cap1.isOpened())
	{
		printf("첫번째 카메라를 열수 없습니다. \n");
	}
	if (!cap2.isOpened())
	{
		printf("두번째 카메라를 열수 없습니다. \n");
	}

	//StreamReader sr = new StreamReader("C:\\Users\\USER\\OneDrive\\바탕 화면\\강의\\동아리\\코드\\pupil center\\start.txt");

	/*
	string in_line;
	ifstream read("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\start.txt");
	while (getline(read,in_line)) {
		cout << in_line << endl;

		if (in_line == "1") {
			state = 1;
			read.close();
		}
	}
	*/
	

	//ofile3.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\realTime.csv");
	

	/*
	ifstream read("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\start.txt");
	read.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\start.txt");
	char str[sizeof(read)] = { '\0' };
	cout << "read의 사이즈:  " << sizeof(read) << endl;
	int i = 0;
	if (read.good()) {
		while (!read.eof()) {
			read.getline(str, sizeof(read));
		}
		cout << "start 읽었음" << endl;
	}
	
	for (i = 0; i < sizeof(read); i++) {
		if (str[i] == '1' ) {
			state = 1;
			cout << '1' << endl;
			read.close();
			//ofile1.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\cal_1.csv");
			//ofile2.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\cal_2.csv");
			//ofile << c[0] << c[1] << endl;
		}
	}
	*/
	//vector<Vec3f> circles;
	for (;;)
	{
		cout << "현재 상태: " << state << endl;
		Mat frame1, frame2, frame3, frame4, frame5;
		//namedWindow("camera1:WEB", 1);
		//namedWindow("camera2:USB", 1);
		//namedWindow("camera3:GRAY", 1);
		namedWindow("camera4:EYE", 1);
		cap1 >> frame1;
		cap2 >> frame2;
		flip(frame2, frame2, 1);
		cvtColor(frame2, frame3, COLOR_BGR2GRAY);
		////cvtColor(frame2, frame3, COLOR_BGR2GRAY);
		////frame3 = ~frame2;
		////frame4 = frame3.clone();
		//medianBlur(frame3, frame3, 5);
		cvtColor(frame3, frame4, COLOR_GRAY2BGR);
		/*threshold(frame3, frame4, 40, 255, THRESH_BINARY);
		frame4 = ~frame4;
		dilate(frame4, frame4, Mat());
		dilate(frame4, frame4, Mat());
		sharpen2D(frame4, frame4);*/
		//resize(frame2, frame2, Size(1280, 960), 0, 0, CV_INTER_LINEAR);
		resize(frame3, frame3, Size(1280, 960), 0, 0, CV_INTER_LINEAR);
		resize(frame4, frame4, Size(1280, 960), 0, 0, CV_INTER_LINEAR);
		HoughCircles(frame3, circles, HOUGH_GRADIENT, 1, 900, 100, 30, 26, 98);
		for (size_t i = 0; i < circles.size(); i++)
		{
			Vec3i c = circles[i];
			Point center(c[0], c[1]);
			int radius = c[2];
			circle(frame4, center, radius, Scalar(0, 255, 0), 2);
			circle(frame4, center, 2, Scalar(0, 0, 255), 3);
			cout << "center" << center << endl;
			if (state2==false&&state == 3 && (double)((clock()-starttime)/CLOCKS_PER_SEC)>=2) {
				ofile3.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\realTime.csv", fstream::out | fstream::app);
				ofile3 << c[0] << ',' << c[1] << endl;//덮어쓰기말고 이어쓰기로
				ofile3.close();
			}
			if (state2 == true && state == 3 && (double)((clock() - starttime) / CLOCKS_PER_SEC) >= 2) {
				ofile3.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\realTime2.csv", fstream::out | fstream::app);
				ofile3 << c[0] << ',' << c[1] << endl;//덮어쓰기말고 이어쓰기로
				ofile3.close();
			}

			if (n >= 0) {
				sum_x += c[0];
				sum_y += c[1];
			}
			n++;
		}
		//imshow("camera1:WEB", frame1);
		//imshow("camera2:USB", frame2);
		//imshow("camera3:GRAY", frame3);
		imshow("camera4:EYE", frame4);
		//imshow("camera5:COLOR", frame5);
		//frame1.release();
		//frame2.release();
		//frame3.release();
		frame4.release();
		if(state2==false)
		{
			if (state == 0)
			{
				string in_line;
				ifstream read("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\start.txt");
				while (getline(read, in_line)) {
					cout << in_line << endl;

					if (in_line == "1") {
						state = 1;
						read.close();
					}
				}
				n = 0;
				sum_x = 0;
				sum_y = 0;
			}
			cout << "n은?:  " << n << endl;
			cout << "State1:  " << state << "  State2:  " << state2 << endl;
			cout << "\nsumx:  " << sum_x << endl;
			cout << "\nsumy:  " << sum_y<<"\n\n" << endl;


			if (n == 60)
			{
				sum_x = sum_x / n;
				sum_y = sum_y / n;
				if (state == 1)
				{
					cout << "~~~~~~~~~~~~~~~~~~" << endl;
					t1.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\startcali2.txt");//첫번째 캘리브레이션 끝나면 다음꺼 오브젝트 열라고 메세지 보내는 것
					t1 << "1";// << endl;
					t1.close();

					cout << "\nend\n" << endl;
					ofile1.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\cal_1.csv");

					ofile1 << sum_x << ',' << sum_y << endl;
					ofile1.close();
					sum_x = 0;
					sum_y = 0;
					n = -5;
					state = 2;
				}
				else if (state == 2)
				{
					t2.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\startnextScene.txt");//두번째 캘리브레이션 끝나면 화면전환해라하는 메세지 띄움
					t2 << "1";// << endl;
					t2.close();
					cout << "\nend\n" << endl;
					ofile2.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\cal_2.csv");
					ofile2 << sum_x << ',' << sum_y << endl;
					ofile2.close();
					state = 3;
					starttime = clock();


				}
			}
			//changeState.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\password.txt");
			int changeState = _access("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\password.txt", 0);//0존재 -1존재x
			if (state == 3 && changeState==0)
			{
				state = 0;
				state2 = true;
				n = 0;
				sum_x = 0;
				sum_y = 0;
			}
		}

		//===================
	
		if (state2 == true)
		{
			if (state == 0)
			{
				string in_line;
				ifstream read("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-1.txt");
				while (getline(read, in_line)) {
					cout << in_line << endl;

					if (in_line == "1") {
						state = 1;
						read.close();
					}
				}
				n = 0;
				sum_x = 0;
				sum_y = 0;
			}
			cout << "n은?:  " << n << endl;
			cout << "\nsumx:  " << sum_x << endl;
			cout << "\nsumy:  " << sum_y << "\n\n" << endl;


			if (n == 60) {
				sum_x = sum_x / n;
				sum_y = sum_y / n;
				if (state == 1) {
					cout << "~~~~~~~~~~~~~~~~~~" << endl;
					t1.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-1-startcali2.txt");//첫번째 캘리브레이션 끝나면 다음꺼 오브젝트 열라고 메세지 보내는 것
					t1 << "1";// << endl;
					t1.close();

					cout << "\nend\n" << endl;
					ofile1.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-cal_1.csv");

					ofile1 << sum_x << ',' << sum_y << endl;
					ofile1.close();
					sum_x = 0;
					sum_y = 0;
					n = -5;
					state = 2;
				}
				else if (state == 2) {
					t2.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-1-tonextScene.txt");//두번째 캘리브레이션 끝나면 화면전환해라하는 메세지 띄움
					t2 << "1";// << endl;
					t2.close();
					cout << "\nend\n" << endl;
					ofile2.open("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-cal_2.csv");
					ofile2 << sum_x << ',' << sum_y << endl;
					ofile2.close();
					state = 3;
					starttime = clock();

				}


			}

		}

		


		if (waitKey(20) == 27) break; //ESC키 누르면 종료
	}
	//read.close();
	//ofile3.close();
	return 0;
}