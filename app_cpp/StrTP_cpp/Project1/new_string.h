#include <iostream>
#include <cstring>
#include <string>
class String {
private:
    static const int MAX_SIZE = 255;
    char data[MAX_SIZE + 1]; // +1 for storing the length of the string

public:
    String() {
        data[0] = 0; // initialize the length of the string to 0
    }

    String(const char* str) {
        int len = strlen(str);
        if (len > MAX_SIZE) {
            len = MAX_SIZE;
        }
        data[0] = len;
        strncpy(data + 1, str, len);
    }

    int length() const {
        return data[0];
    }
    int find(const char* substr) const {
        int len = data[0];
        int subLen = strlen(substr);
        for (int i = 1; i <= len - subLen + 1; i++) {
            bool found = true;
            for (int j = 0; j < subLen; j++) {
                if (data[i + j] != substr[j]) {
                    found = false;
                    break;
                }
            }
            if (found) {
                return i - 1;
            }
        }
        return -1;
    }

    void remove(int start, int count) {
        int len = data[0];
        if (start < 0 || start >= len || count <= 0) {
            return;
        }
        if (start + count > len) {
            count = len - start;
        }
        memmove(data + start + 1, data + start + count + 1, len - start - count);
        data[0] -= count;
    }

    void insert(int pos, const char* substr) {
        int len = strlen(substr);
        if (len == 0) {
            return;
        }
        int oldLen = data[0];
        if (oldLen + len > MAX_SIZE) {
            len = MAX_SIZE - oldLen;
        }
        memmove(data + pos + len + 1, data + pos + 1, oldLen - pos);
        strncpy(data + pos + 1, substr, len);
        data[0] += len;
    }

    String concatenate(const String& other) const {
        String result;
        int len1 = data[0];
        int len2 = other.data[0];
        if (len1 + len2 > MAX_SIZE) {
            len2 = MAX_SIZE - len1;
        }
        result.data[0] = len1 + len2;
        strncpy(result.data + 1, data + 1, len1);
        strncpy(result.data + len1 + 1, other.data + 1, len2);
        return result;
    }

    friend std::ostream& operator<<(std::ostream& os, const String& str) {
        for (int i = 0; i < str.data[0]; i++) {
            os << str.data[i + 1];
        }
        return os;
    }
};
