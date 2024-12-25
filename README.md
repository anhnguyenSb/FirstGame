# Git Flow cho Đội Ngũ Làm Game (20 người gồm Developer và Artist)

## Tổng Quan
Git Flow này được thiết kế để quản lý hiệu quả sự hợp tác giữa các developer (lập trình viên) và artist (nghệ sĩ), đảm bảo sự phối hợp nhịp nhàng trong dự án làm game.

### Mục tiêu:
1. **Dễ dàng quản lý mã nguồn**: Cho phép các developer làm việc trên code mà không ảnh hưởng đến công việc của nhau.
2. **Tích hợp nghệ thuật và tài sản game**: Quản lý các tài sản game (hình ảnh, âm thanh, mô hình 3D) hiệu quả.
3. **Đảm bảo chất lượng**: Kiểm tra, tích hợp, và phát hành không làm gián đoạn quy trình làm việc.

---

## Cấu trúc Nhánh

### 1. **Nhánh chính:**
- **`main`**: Chứa mã nguồn của phiên bản phát hành chính thức.
  - Mọi thay đổi trong nhánh này phải được kiểm tra kỹ lưỡng.
  - Chỉ merge các nhánh `release/*` hoặc `hotfix/*`.
- **`develop`**: Chứa mã nguồn đang trong quá trình phát triển (tập hợp từ các nhánh tính năng).
  - Đây là nhánh chính cho việc phát triển, mọi tính năng mới hoặc thay đổi đều được hợp nhất vào đây.

### 2. **Nhánh phụ:**
- **`feature/*`**: Cho từng tính năng hoặc nhiệm vụ (cả code và tài sản).
  - Tạo nhánh này từ `develop`.
  - Dùng cho các nhiệm vụ như thêm tính năng game hoặc tạo tài sản nghệ thuật.
  - Ví dụ: `feature/player-movement`, `feature/new-character-design`.
  - Sau khi hoàn thành, merge vào `develop` thông qua Pull Request.

- **`hotfix/*`**: Sửa lỗi nghiêm trọng cần triển khai ngay.
  - Tạo nhánh này từ `main`.
  - Dùng cho các lỗi ảnh hưởng trực tiếp đến người dùng.
  - Sau khi sửa lỗi, merge vào cả `main` và `develop`.

- **`release/*`**: Chuẩn bị phát hành phiên bản.
  - Tạo nhánh này từ `develop` khi sẵn sàng chuẩn bị phát hành.
  - Dùng để kiểm tra tổng thể và xử lý lỗi nhỏ trước khi phát hành.
  - Sau khi sẵn sàng, merge vào `main` và tag phiên bản (e.g., `v1.0.0`).

- **`art-assets`**: Nhánh dành riêng cho artist để quản lý tài sản game.
  - Có thể tạo từ `develop` hoặc sử dụng nhánh phụ riêng theo dự án.
  - Chia các thư mục rõ ràng cho từng loại tài sản (e.g., `textures/`, `audio/`, `models/`).

---

## Quy Trình Làm Việc

### 1. **Khởi tạo công việc:**
- **Developer:** Tạo nhánh từ `develop` với tên `feature/*`.
- **Artist:** Tạo nhánh từ `develop` hoặc dùng nhánh chung như `art-assets` để quản lý tài sản (chia thư mục rõ ràng).

### 2. **Phát triển tính năng:**
1. Pull cập nhật từ nhánh `develop` để đảm bảo làm việc với mã nguồn mới nhất.
2. Hoàn thành công việc trong nhánh riêng.

### 3. **Review và Merge:**
- **Pull Request:** Khi hoàn thành tính năng, mở Pull Request (PR) về `develop`.
- **Quy tắc Merge:**
  - Chỉ merge khi PR đã được duyệt bởi ít nhất 2 thành viên trong nhóm (1 Developer và 1 QA hoặc Lead).
  - Đảm bảo không có xung đột trước khi merge.
  - Mọi commit trong PR phải được "squash" (gộp lại) thành một commit duy nhất, mô tả công việc rõ ràng.
  - Các PR lớn (bao gồm nhiều thay đổi) cần được phân tích và kiểm tra kỹ lưỡng.
  - Đối với artist, tài sản được merge cần phải được kiểm tra tính tương thích và không làm tăng kích thước dự án quá mức.

- **Kiểm tra:**
  - Code được code review bởi các developer khác.
  - Tài sản được kiểm tra bởi trưởng nhóm hoặc QA.
- **Merge:** Merge vào `develop` sau khi được phê duyệt.

### 4. **Kiểm tra phiên bản phát hành:**
- Tạo nhánh `release/*` từ `develop`.
- Kiểm tra tổng thể (bao gồm cả mã nguồn và tài sản).
- Khi sẵn sàng, merge `release/*` vào `main` và tag phiên bản (e.g., `v1.0.0`).

### 5. **Sửa lỗi khẩn cấp:**
- Tạo nhánh `hotfix/*` từ `main`.
- Sửa lỗi, kiểm tra và merge lại `main` và `develop`.

---

## Phân Quyền và Quy Ước

### 1. **Phân Quyền:**
- **Developers:** Làm việc trên code và script.
- **Artists:** Làm việc trên các file tài sản (art assets).
- **Lead/Manager:** Duyệt Pull Request và quản lý nhánh chính.

### 2. **Quy Ước:**
- Tên nhánh: 
  - `feature/*`: Tính năng cụ thể, ví dụ: `feature/add-soundtrack`.
  - `hotfix/*`: Sửa lỗi nghiêm trọng, ví dụ: `hotfix/fix-bug-x`.
  - `release/*`: Phiên bản phát hành, ví dụ: `release/v1.0.0`.
- Commit: Mô tả rõ ràng công việc đã làm.
  - **Developer:** `[Feature] Implement player movement logic.`
  - **Artist:** `[Art] Add new texture for background.`

---

## Công Cụ Hỗ Trợ
- **Git LFS (Large File Storage):** Dành cho các file lớn như hình ảnh, âm thanh, video.
- **Code Review Tool:** GitHub/GitLab Merge Request với comment.
- **CI/CD:** Thiết lập pipeline để tự động build và kiểm tra.
- **Trello/Jira:** Quản lý nhiệm vụ và tiến độ.

---

## Lưu Ý
- Đảm bảo đồng bộ giữa code và tài sản khi merge.
- Luôn chạy kiểm tra (build thử game) trước khi merge vào `develop` hoặc `main`.
- Định kỳ dọn dẹp nhánh cũ không còn sử dụng.
