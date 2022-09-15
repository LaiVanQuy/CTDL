#include<stdio.h>
#include<conio.h>
#include<string.h>
struct  CongNhan
{
	int ma;
	char ten[100];
	enum mucBaoHiem{thap, vua, cao};
	float dienTich;
	int veHuu; // 0.chua 1.roi
};
void TaoCongNhan(CongNhan &A)
{ 
	printf("\nEnter employee's ID: ");
	scanf("%d",&A.ma);
	printf("\nEnter employee's' name: "); 
	getchar();
	fgets(A.ten,sizeof(A.ten),stdin);	
	printf("\nEnter square that employee owns (ha): ");
	scanf("%f",&A.dienTich);
	printf("\nEmployee's retirement (0.Not yet | 1.Yes): =>    ");
    int param;
	do
	{
		scanf("%d",&param);
		
		if(param != 0 && param != 1 )
			printf("\nEmployee's retirement (0.Not yet | 1.Yes): => ");
	}while(param != 0 && param != 1);
	A.veHuu = param;	
}
void TaoCongNhan1(CongNhan &A, int ma, char ten[], float dienTich, int veHuu)
{
	A.ma = ma;
	strcpy(A.ten,ten);
	A.dienTich = dienTich;
	A.veHuu = veHuu;
}
void XuatCongNhan(CongNhan A)
{
	char str[100];
	if(A.veHuu == 1)

		strcpy(str,"Retired");
	else
		strcpy(str,"Still Working");	
	printf("\n=> Employee's ID : %d\nEmployee's name:  %sArea that employee owns: %.1f (ha)\nStatus: %s\n",A.ma,A.ten,A.dienTich,str);
}
struct  Node
{
	struct CongNhan data;
	struct Node* pPre, * pNext;
};
struct List
{
	Node *pHead, *pTail;
};
void InitList(List &A)
{
	A.pHead = A.pTail = NULL;
}
int IsEmptyList(List A)
{
	if(A.pHead == NULL)
		return 1;
	return 0;
}
Node* CreateNode(CongNhan x)
{
	Node* p = new Node;
	if(p == NULL)
	{
		printf("khong du bo nho\n");
		return NULL;
	}
	p->data = x;
	p->pNext = NULL; p -> pPre = NULL;
	return p;
}
void AddFirst(List &A, Node* B)
{
	if(IsEmptyList(A) == 1)
		A.pHead = A.pTail = B;
	else
	{
		A.pHead->pPre = B;
		B->pNext = A.pHead;
		B->pPre = NULL;
		A.pHead = B;
	}
}
void AddLast(List&A, Node *B)
{
	if(IsEmptyList(A) == 1)
		A.pHead = A.pTail = B;
	else
	{
		A.pTail->pNext = B;
		B->pPre = A.pTail;
		B->pNext = NULL;
		A.pTail = B;
	}
}
void AddAfter(List &A, Node*B, Node*C)
{
	if(B == A.pTail)
		AddLast(A,C);
	else
	{
		Node*p = B->pNext;
		p->pPre = C;
		B->pNext = C;
		C->pNext = p;
		C->pPre = B;
	}
}
void RemoveFirst(List &A)
{
	if(IsEmptyList(A) == 1)
		printf("\nDanh sach trong\n");
	else if(A.pHead == A.pTail)
	{
		InitList(A);
	}
	else
	{
		Node*p = A.pHead;
		A.pHead = p->pNext;
		delete p;
	}
}
void RemoveLast(List &A)
{
	if(IsEmptyList(A) == 1)
		printf("\nDanh sach trong\n");
	else
	{
		if(A.pHead == A.pTail)
		 	InitList(A);
		else
		{
			Node* p = A.pTail;
			A.pTail = p->pPre;
			A.pTail->pNext = NULL;
			delete p;
		}
	}
}
void RemoveNode(List &A, Node*B)
{
	if(B==A.pHead  &&  B==A.pTail)
		InitList(A);
	else if(B == A.pHead)
	{
		RemoveFirst(A);
	}
	else if(B == A.pTail)
	{
		RemoveLast(A);
	}
	else
	{
		Node* p = B->pPre;
		Node* q = B->pNext;
		p->pNext = q;
		q->pPre = p;
		delete B;
	}
}
void RemoveAfter(List &A, Node* B)
{
	if(B == A.pTail)
		return;
	else if(B == A.pTail->pPre)
		RemoveLast(A);
	else
	{
		Node*p = B->pNext;
		B->pNext = p->pNext;
		Node*q = p->pNext;
		q->pPre = B;
		delete p;
	}
}
Node *SearchNode(List &A, Node* B)
{
	int found = 0;
	Node *p;
	for(p=A.pHead;p!=NULL;p=p->pNext)
	{
		if(p == B)
			{
				printf("found!");
				found++;
				return p;
			}
	}
	if(found==0)
	{
		printf("\nKhong tim thay\n");
		return NULL;
	}
}
Node *SearchNodeAdvance(List &A, int ma)
{
	int found = 0;
	Node *p;
	for(p=A.pHead;p!=NULL;p=p->pNext)
	{
		if(p->data.ma == ma)
			{
				found++;
				return p;
			}
	}
	if(found==0)
	{
		return NULL;
	}
}
void PrintList(List A)
{
	if(IsEmptyList(A) == 1)
		printf("\nThe list is empty\n");
	else
	{
		printf("\n--------------- Your List ---------------\n");
		Node *p = A.pHead;
		while(p != NULL)
		{
			XuatCongNhan(p->data);
			p=p->pNext;
		};
		printf("\n-----------------------------------------\n");
	}
}
int IsLengthList(List A)
{
	int count = 0;
	Node *p = A.pHead;
	while(p!=NULL)
	{
		p = p->pNext;
		count++;
	}
	return count;
}
void SelectionSort(List &A)
{
	List B; InitList(B);
	int n = IsLengthList(A);
	for(int i=0;i<n;i++)
	{
		Node *pMin = A.pHead;
		Node *p = A.pHead->pNext;
		while(p!=NULL)
		{
			if(p->data.dienTich < pMin->data.dienTich)
				pMin = p;
			p = p->pNext;			
		}
		RemoveNode(A,pMin);
		AddLast(B,pMin);
	}
	A = B;
}
void QuickSort(List&A)
{
	List A1; InitList(A1); List A2; InitList(A2);
	Node *pivot, *p;
	if(A.pHead == A.pTail)
		return;
	pivot = A.pHead;
	p = A.pHead -> pNext;
	while(p!=NULL)
	{
		Node*q = p;
		p = p->pNext;
		q->pNext = NULL;
		if(q->data.dienTich <pivot->data.dienTich)
			AddLast(A1,q);
		else
			AddLast(A2,q);
	}
	QuickSort(A1);
	QuickSort(A2);
	if(!IsEmptyList(A1))
	{
		A.pHead = A1.pHead;
		A1.pTail ->pNext = pivot;
	}
	else
	{
		A.pHead = pivot;
	}
	pivot->pNext = A2.pHead;
	if(!IsEmptyList(A2))
	{
		A.pTail = A2.pTail;
	}
	else
		A.pTail = pivot;
}
void MergeLists(List &C, List A, List B)
{
	List D; InitList(D);
	A.pTail->pNext = B.pHead;
	B.pHead->pPre = A.pTail;
	D.pHead = A.pHead;
	D.pTail = B.pTail;
	C = D;
}
void RemoveNodesAdvance(List &A, float dt)
{
	Node *p = A.pHead;
	while(p!=NULL)
	{
		Node *q = p;
		p=p->pNext;
		if(q->data.dienTich == dt)
			RemoveNode(A,q);
	}
}
void PrintReverseList(List A)
{
	if(IsEmptyList(A) == 1)
		printf("\nThe list is empty\n");
	else
	{
		printf("\n--------------- Reverse List: ---------------\n");
		Node *p = A.pTail;
		while(p != NULL)
		{
			XuatCongNhan(p->data);
			p=p->pPre;
		};
		printf("\n---------------------------------------------\n");
	}
}
void DeleteList(List &A)
{
	Node* p = A.pHead;
	while(p!=NULL)
	{
		Node *q = p;
		p = p->pNext;
		RemoveNode(A,q);
	}
}

void PrintOption()
{
	printf("\t\t	                Employee Management Application	\n");
	printf("\t\t---------------------------------- Option ----------------------------------\n");
	printf("\t\t| 1.  Print the the present Employee's list                                |\n");
	printf("\t\t| 2.  Insert a new Employee at the beginning of the list                   |\n");
	printf("\t\t| 3.  Insert a new Employee at the end of the list                         |\n");
	printf("\t\t| 4.  Insert a new Employee after the first Employee in the list           |\n");
	printf("\t\t| 5.  Remove an Employee at the beginning of the list                      |\n");
	printf("\t\t| 6.  Remove an Employee at the end of the list                            |\n");
	printf("\t\t| 7.  Remove an Employee after the first Employee in the list              |\n");
	printf("\t\t| 8.  Search Employee by ID:                                               |\n");
	printf("\t\t| 9.  Sort the list by the area that the Employee own  (Selection Sort)    |\n");
	printf("\t\t| 10. Sort the list by the area that the Employee own (Quick Sort)         |\n");
	printf("\t\t| 11. Delete List                                                          |\n");
	printf("\t\t| 12. Print the reverse list                                               |\n");
	printf("\t\t| 13. Merge Lists                                                          |\n");
	printf("\t\t| 0.  Exit the application                                                 |\n");
	printf("\t\t----------------------------------------------------------------------------\n");
}
void CreateAvailableList(List &A)
{
	CongNhan A1; CongNhan A2;
	int ma1, ma2; ma1 = 9999; ma2 = 9998; 
	char ten1[100], ten2[100]; strcpy(ten1,"Lai Van Quy\n"); strcpy(ten2,"Tran The Vy\n");
	float dienTich1, dienTich2; dienTich1 = 2.3; dienTich2 = 1.1;
	int veHuu1, veHuu2; veHuu1 = 0; veHuu2= 1;
	TaoCongNhan1(A1,ma1,ten1,dienTich1,veHuu1);
	TaoCongNhan1(A2,ma2,ten2,dienTich2,veHuu2);
	Node*p = CreateNode(A1); Node *q = CreateNode(A2);
	AddLast(A,p); AddLast(A,q);
}
int main()
{
	PrintOption();
	CongNhan a[100]; Node* b[100]; // Tao bien cac con tro va bien CongNhan
	List A,B;
	InitList(B); CreateAvailableList(B); // khoi tao du lieu co san cho List thu 2
	int indexEmployee = 0; // thu tu bien con tro va bien CongNhan
	int option; // bien cac option
	do
	{	
		printf("\nEnter your option: "); scanf("%d",&option);
		switch(option)
		{
			case 1: 
			{
				PrintList(A);
				break;
			}
			case 2:
			{
				TaoCongNhan(a[indexEmployee]);  // cho phep nguoi dung nhap thong tin cong nhan
				b[indexEmployee] = CreateNode(a[indexEmployee]);
				if(SearchNodeAdvance(A,b[indexEmployee]->data.ma)==NULL) // kiem tra co trung ID hay khong
				{
					AddFirst(A,b[indexEmployee]);
					indexEmployee++;
					break;
				}
				else
				{
					printf("\n*--- The Employee's ID is existed ---*\n"); // truong hop bi trung
					break;
				}				
			}
			case 3:
			{
				TaoCongNhan(a[indexEmployee]);  // cho phep nguoi dung nhap thong tin cong nhan
				b[indexEmployee] = CreateNode(a[indexEmployee]);
				if(SearchNodeAdvance(A,b[indexEmployee]->data.ma)==NULL) // kiem tra co trung ID hay khong
				{
					AddLast(A,b[indexEmployee]);
					indexEmployee++;
					break;
				}
				else
				{
					printf("\n*--- The Employee's ID is duplicated ---*\n"); // truong hop bi trung
					break;
				}
			}
			case 4:
			{
				TaoCongNhan(a[indexEmployee]); // cho phep nguoi dung nhap thong tin cong nhan
				b[indexEmployee] = CreateNode(a[indexEmployee]);
				if(SearchNodeAdvance(A,b[indexEmployee]->data.ma)==NULL) // kiem tra co trung ID hay khong
				{
					AddAfter(A,A.pHead,b[indexEmployee]);
					indexEmployee++;
					break;
				}
				else
				{
					printf("\n*--- The Employee's ID is duplicated ---*\n"); // truong hop bi trung
					break;
				}
			}
			case 5:
			{
				RemoveFirst(A); // xoa cong nhan dau tien trong list
				printf("\n*--- Removed ---*\n");
				break;
			}
			case 6:
			{
				RemoveLast(A); // xoa cong nhan cuoi cung trong list
				printf("\n*--- Removed ---*\n");
				break;
			}
			case 7:
			{
				RemoveAfter(A,A.pHead); // xoa cong nhan sau cong nhan dau tien
				printf("\n*--- Removed ---*\n");
				break;
			}
			case 8:
			{
				int id;
				printf("\nEnter Employee's ID: ");
				scanf("%d",&id);
				Node*p = SearchNodeAdvance(A,id); // tim kiem cong nhan theo id
				if(p == NULL)					
				{
					printf("\n=> Not Found!\n");
					break;
				}
				else
				{
					printf("\nResult: ");
					XuatCongNhan(p->data);
					break;
				}
			}
			case 9:
			{
				SelectionSort(A);
				printf("\n  Success  \n");
				break;
			}
			case 10:
			{
				QuickSort(A);
				printf("\n  Success  \n");
				break;
			}
			case 13:
			{
				List C = A;
				MergeLists(A,C,B);
				printf("\n  Success  \n");
				break;
			}
			case 12:
			{
				PrintReverseList(A);
				break;
			}
			case 11:
			{
				DeleteList(A);
				printf("\n  Success  \n");
				break;
			}
			case 0:
			{
				option = 0;
				break;
			}
		}
	} while (option != 0);
	printf("\n	Thanks for using our application!");
	getch();
}
